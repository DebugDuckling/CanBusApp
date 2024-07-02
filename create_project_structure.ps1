param (
    [string]$projectName = "CanBusApp"
)

# Create the project directory
New-Item -Path $projectName -ItemType Directory -Force
Set-Location -Path $projectName

# Create the solution and project
dotnet new sln -n $projectName
dotnet new winforms -n $projectName

# Add project to solution
dotnet sln add "$projectName\$projectName.csproj"

# Move to the project directory
Set-Location -Path $projectName

# Add Newtonsoft.Json package
dotnet add package Newtonsoft.Json

# Create commands_config.json
$jsonConfig = @'
{
  "commands": [
    { "label": "Command 1", "options": ["enum 1", "enum 2", "enum 3", "enum 4"], "defaultValue": "enum 2" },
    { "label": "Command 2", "options": ["enum 1", "enum 2", "enum 3", "enum 4"], "defaultValue": "enum 1" },
    { "label": "Command 3", "options": ["enum 1", "enum 2", "enum 3", "enum 4"], "defaultValue": "enum 4" },
    { "label": "Command 4", "options": ["enum 1", "enum 2", "enum 3", "enum 4"], "defaultValue": "enum 3" },
    { "label": "Command 5", "options": ["enum 1", "enum 2", "enum 3", "enum 4"], "defaultValue": "enum 1" }
  ],
  "status": [
    { "label": "Status 1", "defaultValue": "Initial Status 1" },
    { "label": "Status 2", "defaultValue": "Initial Status 2" },
    { "label": "Status 3", "defaultValue": "Initial Status 3" },
    { "label": "Status 4", "defaultValue": "Initial Status 4" }
  ]
}
'@
$jsonConfig | Out-File -FilePath "commands_config.json" -Encoding utf8

# Ensure commands_config.json is copied to the output directory
# Add the following lines to the .csproj file
$csprojPath = "$projectName.csproj"
$csprojContent = Get-Content -Path $csprojPath
$insertIndex = [Array]::IndexOf($csprojContent, '</Project>')

$beforeInsert = $csprojContent[0..($insertIndex - 1)]
$afterInsert = $csprojContent[$insertIndex..($csprojContent.Length - 1)]

$additionalContent = @'
  <ItemGroup>
    <None Update="commands_config.json">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
  </ItemGroup>
'@

$updatedCsprojContent = $beforeInsert + $additionalContent + $afterInsert
$updatedCsprojContent | Set-Content -Path $csprojPath

# Create CanBusModel.cs
$canBusModel = @'
using System.Collections.Generic;

public class CanBusModel
{
    public string NodeId { get; set; }
    public string State { get; set; }
    public int SendCount { get; set; }
    public int ReceiveCount { get; set; }
    public bool Continuously { get; set; }
    public bool Auto { get; set; }
    public List<Command> Commands { get; set; } = new List<Command>();
    public bool Mode { get; set; }
    public bool Enabler1 { get; set; }
    public bool Enabler2 { get; set; }
    public string Val1 { get; set; }
    public string Val2 { get; set; }
    public List<Status> Statuses { get; set; } = new List<Status>();
}

public class Command
{
    public string Label { get; set; }
    public List<string> Options { get; set; }
    public string DefaultValue { get; set; }
}

public class Status
{
    public string Label { get; set; }
    public string DefaultValue { get; set; }
}
'@
$canBusModel | Out-File -FilePath "CanBusModel.cs" -Encoding utf8

# Create ConfigLoader.cs
$configLoader = @'
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public static class ConfigLoader
{
    public static CanBusModel LoadConfiguration(string path)
    {
        var json = File.ReadAllText(path);
        var config = JsonConvert.DeserializeObject<ConfigModel>(json);
        return new CanBusModel
        {
            Commands = config.Commands,
            Statuses = config.Status
        };
    }
}

public class ConfigModel
{
    public List<Command> Commands { get; set; }
    public List<Status> Status { get; set; }
}
'@
$configLoader | Out-File -FilePath "ConfigLoader.cs" -Encoding utf8

# Replace Form1.cs
$form1 = @'
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CanBusApp
{
    public partial class Form1 : Form
    {
        private CanBusModel model;
        private Dictionary<string, ComboBox> commandComboBoxes = new Dictionary<string, ComboBox>();
        private Dictionary<string, TextBox> statusTextBoxes = new Dictionary<string, TextBox>();

        public Form1()
        {
            InitializeComponent();
            model = ConfigLoader.LoadConfiguration("commands_config.json");
            InitializeDynamicComponents();
        }

        private void InitializeDynamicComponents()
        {
            int yPosition = 60;

            // Commands section
            var commandsGroup = new GroupBox
            {
                Text = "Commands (Send to device)",
                Location = new Point(10, yPosition),
                Size = new Size(300, 300)
            };
            Controls.Add(commandsGroup);

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
                    Width = 100
                };
                if (command.Options.Contains(command.DefaultValue))
                {
                    comboBox.SelectedItem = command.DefaultValue;
                }
                commandsGroup.Controls.Add(comboBox);
                commandComboBoxes[command.Label] = comboBox;

                yPosition += 30;
            }

            // Status section
            yPosition = 60;
            var statusGroup = new GroupBox
            {
                Text = "Status (Receive from device)",
                Location = new Point(350, yPosition),
                Size = new Size(300, 300)
            };
            Controls.Add(statusGroup);

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
                    Text = status.DefaultValue
                };
                statusGroup.Controls.Add(textBox);
                statusTextBoxes[status.Label] = textBox;

                yPosition += 30;
            }
        }

        public string NodeId => txtNodeId.Text;
        public string State => txtState.Text;
        public int SendCount => int.Parse(txtSendCount.Text);
        public int ReceiveCount => int.Parse(txtReceiveCount.Text);
        public bool Continuously => chkContinuously.Checked;
        public bool Auto => chkAuto.Checked;

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
'@
$form1 | Out-File -FilePath "Form1.cs" -Encoding utf8 -Force

# Replace Form1.Designer.cs
$form1Designer = @'
namespace CanBusApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Button connectButton;
        private TextBox txtNodeId;
        private TextBox txtState;
        private TextBox txtSendCount;
        private TextBox txtReceiveCount;
        private CheckBox chkContinuously;
        private CheckBox chkAuto;

        private void InitializeComponent()
        {
            this.connectButton = new System.Windows.Forms.Button();
            this.txtNodeId = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtSendCount = new System.Windows.Forms.TextBox();
            this.txtReceiveCount = new System.Windows.Forms.TextBox();
            this.chkContinuously = new System.Windows.Forms.CheckBox();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();

            // connectButton
            this.connectButton.Location = new System.Drawing.Point(700, 20);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;

            // txtNodeId
            this.txtNodeId.Location = new System.Drawing.Point(20, 20);
            this.txtNodeId.Name = "txtNodeId";
            this.txtNodeId.Size = new System.Drawing.Size(100, 20);
            this.txtNodeId.TabIndex = 1;

            // txtState
            this.txtState.Location = new System.Drawing.Point(140, 20);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(100, 20);
            this.txtState.TabIndex = 2;

            // txtSendCount
            this.txtSendCount.Location = new System.Drawing.Point(260, 20);
            this.txtSendCount.Name = "txtSendCount";
            this.txtSendCount.Size = new System.Drawing.Size(100, 20);
            this.txtSendCount.TabIndex = 3;

            // txtReceiveCount
            this.txtReceiveCount.Location = new System.Drawing.Point(380, 20);
            this.txtReceiveCount.Name = "txtReceiveCount";
            this.txtReceiveCount.Size = new System.Drawing.Size(100, 20);
            this.txtReceiveCount.TabIndex = 4;

            // chkContinuously
            this.chkContinuously.Location = new System.Drawing.Point(500, 20);
            this.chkContinuously.Name = "chkContinuously";
            this.chkContinuously.Size = new System.Drawing.Size(80, 20);
            this.chkContinuously.TabIndex = 5;
            this.chkContinuously.Text = "Continuously";

            // chkAuto
            this.chkAuto.Location = new System.Drawing.Point(600, 20);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(50, 20);
            this.chkAuto.TabIndex = 6;
            this.chkAuto.Text = "Auto";

            // Form1
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.txtNodeId);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.txtSendCount);
            this.Controls.Add(this.txtReceiveCount);
            this.Controls.Add(this.chkContinuously);
            this.Controls.Add(this.chkAuto);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
'@
$form1Designer | Out-File -FilePath "Form1.Designer.cs" -Encoding utf8 -Force

# Create CanBusController.cs
$canBusController = @'
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
'@
$canBusController | Out-File -FilePath "CanBusController.cs" -Encoding utf8

# Build the project
dotnet build
