using System;
using System.Runtime.InteropServices;

namespace ArcnetDriver
{
    // Define the COM20020_CONFIG structure
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct COM20020_CONFIG
    {
        public ushort uiCom20020BaseIOAddress;
        public byte byCom20020InterruptLevel;
        public byte byCom20020Timeout;
        public byte byCom20020NodeID;
        public byte bCom20020_128NAKs;
        public byte bCom20020ReceiveAll;
        public byte byCom20020ClockPrescaler;
        public byte bCom20020SlowArbitration;
        public byte bCom20020ReceiveBroadcasts;
    }

    // Define the COM20020_TRANSMIT_BUFFER structure
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct COM20020_TRANSMIT_BUFFER
    {
        public byte byDestinationNodeID;
        public ushort uiNumberOfBytes;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 508)]
        public byte[] byDataBuffer;
    }

    // Define the COM20020_RECEIVE_BUFFER structure
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct COM20020_RECEIVE_BUFFER
    {
        public byte bySourceNodeID;
        public byte byDestinationNodeID;
        public ushort uiNumberOfBytes;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 508)]
        public byte[] byDataBuffer;
        public uint dwNumberOfFilledBuffers;
    }

    // Define the COM20020_STATUS structure
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct COM20020_STATUS
    {
        public byte bReceiveActivity;
        public byte bPowerOnReset;
        public byte bRecon;
        public byte bToken;
        public uint dwReceivedMessages;
        public byte bTransmissionComplete;
        public byte bTransmissionAcknowledged;
        public byte bExcessiveNAKs;
        public uint dwReserved;
    }

    // Define the COM20020_REGISTER structure
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct COM20020_REGISTER
    {
        public byte bWrite;
        public byte byRegister;
        public byte byValue;
    }

    public static class ArcX
    {
        private const string DLL_NAME = "ArcX.dll";

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Com20020Init(ref COM20020_CONFIG cfg, byte deviceNumber, byte hardwareType);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Com20020Register(ref COM20020_REGISTER reg);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Com20020Status(ref COM20020_STATUS status);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Com20020CancelTX();

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Com20020FlushRX();

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Com20020Transmit(ref COM20020_TRANSMIT_BUFFER txbuf);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Com20020Receive(ref COM20020_RECEIVE_BUFFER rxbuf);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Com20020WakeOnReceive(IntPtr receiveEvent);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Com20020ResetWakeOnReceive();

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Com20020WakeOnTXComplete(IntPtr transmitEvent);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Com20020ResetWakeOnTXComplete();

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Com20020WakeOnRecon(IntPtr reconEvent);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Com20020ResetWakeOnRecon();

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Com20020GetOverflowTotal(ref long packets, ref long data);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Com20020GetFirmwareRevision(ref short rev);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Com20020UsbVersion(ref short version);

        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Com20020Exit();
    }
}
