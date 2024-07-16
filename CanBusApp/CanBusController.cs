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
           // view.UpdateButton.Click += UpdateButton_Click;
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            model.NodeId = view.NodeId;
            model.Commands = view.GetCommands();
            model.Statuses = view.GetStatuses();

            // Update the following lines to set the properties correctly
            model.Recons = int.Parse(view.Recons);
            model.TxState = view.TxState;
            model.TxFrames = int.Parse(view.TxFrames);
            model.RxFrames = int.Parse(view.RxFrames);
            model.TxContinuous = view.TxContinuous;
            model.AutoUpdate = view.AutoUpdate;

            MessageBox.Show("Data collected and stored in buffer.");
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            // Implement the update logic here
            MessageBox.Show("Update button clicked.");
        }
    }
}
