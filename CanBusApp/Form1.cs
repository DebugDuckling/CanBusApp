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
        private Dictionary<string, Control> commandControls = new Dictionary<string, Control>();
        private Dictionary<string, Control> statusControls = new Dictionary<string, Control>();
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

                Control control;
                switch (command.Type)
                {
                    case "combobox":
                        control = new ComboBox
                        {
                            DataSource = command.Options,
                            Location = new Point(150, yPosition),
                            Width = 100,
                            DropDownStyle = ComboBoxStyle.DropDownList
                        };
                        if (!string.IsNullOrEmpty(command.DefaultValue) && command.Options.Contains(command.DefaultValue))
                        {
                            ((ComboBox)control).SelectedItem = command.DefaultValue;
                        }
                        break;

                    case "checkbox":
                        control = new CheckBox
                        {
                            Location = new Point(150, yPosition),
                            Width = 100,
                            Text = command.Label,
                            Checked = bool.Parse(command.DefaultValue ?? "false")
                        };
                        break;

                    case "textbox":
                        control = new TextBox
                        {
                            Location = new Point(150, yPosition),
                            Width = 100,
                            Text = command.DefaultValue
                        };
                        break;

                    case "button":
                        control = new Button
                        {
                            Location = new Point(150, yPosition),
                            Width = 100,
                            Text = command.ButtonText
                        };
                        control.Click += (sender, e) => MessageBox.Show($"Button {command.Label} clicked!");
                        break;

                    default:
                        control = new TextBox
                        {
                            Location = new Point(150, yPosition),
                            Width = 100
                        };
                        break;
                }

                commandsGroup.Controls.Add(control);
                commandControls[command.Label] = control;

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

                Control control;
                switch (status.Type)
                {
                    case "combobox":
                        control = new ComboBox
                        {
                            DataSource = status.Options,
                            Location = new Point(150, yPosition),
                            Width = 100,
                            DropDownStyle = ComboBoxStyle.DropDownList
                        };
                        if (!string.IsNullOrEmpty(status.DefaultValue) && status.Options.Contains(status.DefaultValue))
                        {
                            ((ComboBox)control).SelectedItem = status.DefaultValue;
                        }
                        break;

                    case "checkbox":
                        control = new CheckBox
                        {
                            Location = new Point(150, yPosition),
                            Width = 100,
                            Text = status.Label,
                            Checked = bool.Parse(status.DefaultValue ?? "false")
                        };
                        break;

                    case "textbox":
                        control = new TextBox
                        {
                            Location = new Point(150, yPosition),
                            Width = 100,
                            Text = status.DefaultValue
                        };
                        break;

                    case "button":
                        control = new Button
                        {
                            Location = new Point(150, yPosition),
                            Width = 100,
                            Text = status.ButtonText
                        };
                        control.Click += (sender, e) => MessageBox.Show($"Button {status.Label} clicked!");
                        break;

                    default:
                        control = new TextBox
                        {
                            Location = new Point(150, yPosition),
                            Width = 100
                        };
                        break;
                }

                statusGroup.Controls.Add(control);
                statusControls[status.Label] = control;

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

        private void updateButton_Click(object sender, EventArgs e)
        {
            // Implement the update logic here
        }

        public string NodeId => txtNodeId.Text;
        public string Recons => txtRecons.Text;
        public string TxState => txtTxState.Text;
        public string TxFrames => txtTxFrames.Text;
        public string RxFrames => txtRxFrames.Text;
        public bool TxContinuous => chkTxContinuous.Checked;
        public bool AutoUpdate => chkAutoUpdate.Checked;

        public List<Command> GetCommands()
        {
            var commands = new List<Command>();
            foreach (var kvp in commandControls)
            {
                var control = kvp.Value;
                string value = control switch
                {
                    ComboBox comboBox => comboBox.SelectedItem?.ToString(),
                    CheckBox checkBox => checkBox.Checked.ToString(),
                    TextBox textBox => textBox.Text,
                    _ => string.Empty
                };
                commands.Add(new Command { Label = kvp.Key, DefaultValue = value });
            }
            return commands;
        }

        public List<Status> GetStatuses()
        {
            var statuses = new List<Status>();
            foreach (var kvp in statusControls)
            {
                var control = kvp.Value;
                string value = control switch
                {
                    ComboBox comboBox => comboBox.SelectedItem?.ToString(),
                    CheckBox checkBox => checkBox.Checked.ToString(),
                    TextBox textBox => textBox.Text,
                    _ => string.Empty
                };
                statuses.Add(new Status { Label = kvp.Key, DefaultValue = value });
            }
            return statuses;
        }

        public Button ConnectButton => this.connectButton;
        public Button UpdateButton => this.updateButton;
    }
}
