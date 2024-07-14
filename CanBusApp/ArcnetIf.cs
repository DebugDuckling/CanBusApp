using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace ArcnetDriver
{
    public enum WINMSG
    {
        WINMSG_RECON = 0x0400 + 1,
        WINMSG_RX
    };

    public enum TxState_E
    {
        TxState_ERR = 0,   // Transmission error
        TxState_TMA = 1,   // The message was properly received.
        TxState_NAK = 2,   // Message was killed because of excessive NAKs.
        TxState_NA = 3,    // ?
        TxState_TA = 4     // The message was sent, but not acknowledged.
    };

    public class ArcnetIf
    {
        // General
        private const int LAN_EVENT_TIMEOUT = 100; // Time to wait for events (ms).

        // LAN definitions
        private const int LAN_SPEED = 4;           // Example speed value
        private const int LAN_TIMEOUT = 24;        // Example timeout value
        private const int LAN_DEVICE = 0;          // Device 1
        private const int LAN_HWTYPE = 0;          // USB22
        private const byte LAN_128NAKS = 1;
        private const byte LAN_RXALL = 0;

        // Static variables
        private static bool bRunning = false;              // Indicates if threads are running.
        private static uint dwRecon = 0;                   // Number of recons.
        private static EventWaitHandle hTxEvent = new AutoResetEvent(false); // TX event handle.
        private static EventWaitHandle hRxEvent = new AutoResetEvent(false); // RX event handle.
        private static EventWaitHandle hReconEvent = new AutoResetEvent(false); // Recon event handle.
        private static SemaphoreSlim RxListSema = new SemaphoreSlim(1, 1); // Semaphore to protect the RxList.
        private static Queue<COM20020_RECEIVE_BUFFER> RxMsgList = new Queue<COM20020_RECEIVE_BUFFER>(); // RX messages

        // Static procedures
        private static void ReconThread()
        {
            while (bRunning)
            {
                if (hReconEvent.WaitOne(LAN_EVENT_TIMEOUT))
                {
                    dwRecon++;
                    // Signal event to the UI thread. (Implement this part according to your UI framework)
                }
            }
        }

        private static void ReceiveThread()
        {
            while (bRunning)
            {
                COM20020_RECEIVE_BUFFER crb = new COM20020_RECEIVE_BUFFER(); // Ensure crb is initialized
                if (hRxEvent.WaitOne(LAN_EVENT_TIMEOUT))
                {
                    while (ArcX.Com20020Receive(ref crb) == 0)
                    {
                        RxListSema.Wait();
                        RxMsgList.Enqueue(crb);
                        RxListSema.Release();
                    }
                    // Signal event to the UI thread. (Implement this part according to your UI framework)
                }
            }
        }

        // Constructor
        public ArcnetIf()
        {
      
        }

        // Destructor
        ~ArcnetIf()
        {
            Close();
        }

        // Opens the ARCNET port.
        public bool Open(byte nNodeId, byte bBroadcast)
        {
            bool bResult = false;
            COM20020_CONFIG cfg = new COM20020_CONFIG
            {
                uiCom20020BaseIOAddress = 0,
                byCom20020InterruptLevel = 0,
                byCom20020Timeout = LAN_TIMEOUT,
                byCom20020NodeID = nNodeId,
                bCom20020_128NAKs = LAN_128NAKS,
                bCom20020ReceiveAll = LAN_RXALL,
                byCom20020ClockPrescaler = LAN_SPEED,
                bCom20020SlowArbitration = 0,
                bCom20020ReceiveBroadcasts = bBroadcast
            };

            if (ArcX.Com20020Init(ref cfg, LAN_DEVICE, LAN_HWTYPE) != 0)
            {
                Console.WriteLine("COM20020 was not properly initialized");
            }
            else
            {
                InitDeviceEvents();
                bResult = true;
            }

            return bResult;
        }

        // Closes the ARCNET port.
        public void Close()
        {
            bRunning = false;
            ArcX.Com20020ResetWakeOnReceive();
            ArcX.Com20020ResetWakeOnTXComplete();
            ArcX.Com20020ResetWakeOnRecon();
            ArcX.Com20020CancelTX();
            ArcX.Com20020FlushRX();
            ArcX.Com20020Exit();
            dwRecon = 0;
        }

        // Reports the recon state.
        public bool GetReconState()
        {
            COM20020_STATUS cs = new COM20020_STATUS();
            ArcX.Com20020Status(ref cs);
            return cs.bRecon > 0;
        }

        // Reports the recon counter.
        public uint GetReconCount()
        {
            return dwRecon;
        }

        // Transmits a message.
        public TxState_E TransmitMessage(byte nDestID, byte[] pBuffer, int nLength)
        {
            if (nLength > 508)
                return TxState_E.TxState_ERR;

            bool bTransmissionAcked = false;
            COM20020_TRANSMIT_BUFFER ctb = new COM20020_TRANSMIT_BUFFER
            {
                byDestinationNodeID = nDestID,
                uiNumberOfBytes = (ushort)nLength,
                byDataBuffer = new byte[508]
            };
            Array.Copy(pBuffer, ctb.byDataBuffer, nLength);

            while (!bTransmissionAcked)
            {
                bool bReturn = true;
                while (bReturn)
                {
                    bReturn = ArcX.Com20020Transmit(ref ctb) == 0;
                    hTxEvent.WaitOne(LAN_EVENT_TIMEOUT);
                    COM20020_STATUS cs = new COM20020_STATUS();
                    ArcX.Com20020Status(ref cs);
                    if ((cs.bTransmissionComplete > 0) && (cs.bTransmissionAcknowledged > 0))
                    {
                        return TxState_E.TxState_TMA; // The message was properly received
                    }
                    if ((cs.bTransmissionComplete > 0) && !(cs.bTransmissionAcknowledged > 0))
                    {
                        return TxState_E.TxState_TA; // The message was sent, but not acknowledged.
                    }
                    if (cs.bExcessiveNAKs > 0) // Message was killed because of excessive NAKs
                    {
                        return TxState_E.TxState_NAK;
                    }
                    if (cs.bRecon > 0) // Recon active
                    {
                        return TxState_E.TxState_ERR;
                    }
                }
            }
            return TxState_E.TxState_NAK;
        }

        // Gets the next message in the RX list.
        public bool GetRxMessage(out COM20020_RECEIVE_BUFFER pMsg)
        {
            pMsg = new COM20020_RECEIVE_BUFFER();
            bool bResult = false;
            RxListSema.Wait();
            if (RxMsgList.Count > 0)
            {
                pMsg = RxMsgList.Dequeue();
                bResult = true;
            }
            RxListSema.Release();
            return bResult;
        }

        // Initializes the device events.
        private void InitDeviceEvents()
        {
            hRxEvent = new AutoResetEvent(false);
            ArcX.Com20020WakeOnReceive(hRxEvent.SafeWaitHandle.DangerousGetHandle());
            hTxEvent = new AutoResetEvent(false);
            ArcX.Com20020WakeOnTXComplete(hTxEvent.SafeWaitHandle.DangerousGetHandle());
            bRunning = true;
            Thread reconThread = new Thread(ReconThread);
            reconThread.Start();
            Thread receiveThread = new Thread(ReceiveThread);
            receiveThread.Start();
        }
    }
}
