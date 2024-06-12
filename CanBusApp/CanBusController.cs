using System;
using System.Windows.Forms;

namespace CanBusApp
{
    public class CanBusController
    {
        private readonly CanBusModel model;
        private readonly Form1 view;

        public CanBusController(CanBusModel model, Form1 view)
        {
            this.model = model;
            this.view = view;

            view.ConnectButton.Click += ConnectButton_Click;
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            model.NodeId = view.NodeId;
            model.State = view.State;
            model.SendCount = view.SendCount;
            model.ReceiveCount = view.ReceiveCount;
            model.Continuously = view.Continuously;
            model.Auto = view.Auto;
            model.Commands = view.GetCommands();
            model.Statuses = view.GetStatuses();

            MessageBox.Show("Data collected and stored in buffer.");
        }
    }
}
