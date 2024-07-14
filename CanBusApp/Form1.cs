using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ArcnetDriver;

namespace CanBusApp
{
    public partial class Form1 : Form
    {
        private CanBusModel model;
        private Dictionary<string, ComboBox> commandComboBoxes = new Dictionary<string, ComboBox>();
        private Dictionary<string, TextBox> statusTextBoxes = new Dictionary<string, TextBox>();
        private ArcnetIf arcnetInterface;

        public Form1()
        {
            InitializeComponent();
            model = ConfigLoader.LoadConfiguration("commands_config.json");
            InitializeDynamicComponents();
            arcnetInterface = new ArcnetIf();
        }

        private void InitializeDynamicComponents()
        {
            int yPosition = 30;

            // Commands section
            foreach (var command in model.Commands)
            {
                var label = new Label
                {
                    Text = command.Label,
                    Location = new Point(20, yPosition)
                };
                commandsGroup.Controls.Add(label);

                var comboBox = new ComboBox
                {
                    DataSource = command.Options,
                    Location = new Point(150, yPosition),
                    Width = 100,
                    DropDownStyle = ComboBoxStyle.DropDownList // Ensure dropdown style
                };
                commandsGroup.Controls.Add(comboBox);
                commandComboBoxes[command.Label] = comboBox;

                // Set default value if it exists
                if (!string.IsNullOrEmpty(command.DefaultValue) && command.Options.Contains(command.DefaultValue))
                {
                    comboBox.SelectedItem = command.DefaultValue;
                }

                yPosition += 30;
            }

            // Status section
            yPosition = 30;
            foreach (var status in model.Statuses)
            {
                var label = new Label
                {
                    Text = status.Label,
                    Location = new Point(20, yPosition)
                };
                statusGroup.Controls.Add(label);

                var textBox = new TextBox
                {
                    Location = new Point(150, yPosition),
                    Width = 100,
                    Text = status.DefaultValue // Set default value
                };
                statusGroup.Controls.Add(textBox);
                statusTextBoxes[status.Label] = textBox;

                yPosition += 30;
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            byte nodeId = byte.Parse(txtNodeId.Text);
            byte broadcast = 1; // Example value

            bool success = arcnetInterface.Open(nodeId, broadcast);

            if (success)
            {
                MessageBox.Show("Initialization successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Initialization failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            arcnetInterface.Close();
        }

        public string NodeId => txtNodeId.Text;
        public string Recons => txtRecons.Text;
        public string TxState => txtTxState.Text;
        public int TxFrames => int.Parse(txtTxFrames.Text);
        public int RxFrames => int.Parse(txtRxFrames.Text);
        public bool TxContinuous => chkTxContinuous.Checked;
        public bool AutoUpdate => chkAutoUpdate.Checked;

        public List<Command> GetCommands()
        {
            var commands = new List<Command>();
            foreach (var kvp in commandComboBoxes)
            {
                commands.Add(new Command { Label = kvp.Key, Options = new List<string> { kvp.Value.SelectedItem?.ToString() } });
            }
            return commands;
        }

        public List<Status> GetStatuses()
        {
            var statuses = new List<Status>();
            foreach (var kvp in statusTextBoxes)
            {
                statuses.Add(new Status { Label = kvp.Key, DefaultValue = kvp.Value.Text });
            }
            return statuses;
        }

        public Button ConnectButton => this.connectButton;
    }
}
