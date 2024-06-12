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
        private Label lblTitle;
        private TableLayoutPanel mainLayout;
        private GroupBox commandsGroup;
        private GroupBox statusGroup;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.connectButton = new System.Windows.Forms.Button();
            this.txtNodeId = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtSendCount = new System.Windows.Forms.TextBox();
            this.txtReceiveCount = new System.Windows.Forms.TextBox();
            this.chkContinuously = new System.Windows.Forms.CheckBox();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.commandsGroup = new System.Windows.Forms.GroupBox();
            this.statusGroup = new System.Windows.Forms.GroupBox();

            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Text = "CAN Bus Communication";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // mainLayout
            this.mainLayout.ColumnCount = 5;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.mainLayout.Controls.Add(this.lblTitle, 0, 0);
            this.mainLayout.SetColumnSpan(this.lblTitle, 5);
            this.mainLayout.Controls.Add(this.txtNodeId, 0, 1);
            this.mainLayout.Controls.Add(this.txtState, 1, 1);
            this.mainLayout.Controls.Add(this.txtSendCount, 2, 1);
            this.mainLayout.Controls.Add(this.txtReceiveCount, 3, 1);
            this.mainLayout.Controls.Add(this.chkContinuously, 0, 2);
            this.mainLayout.Controls.Add(this.chkAuto, 1, 2);
            this.mainLayout.Controls.Add(this.connectButton, 4, 2);
            this.mainLayout.Controls.Add(this.commandsGroup, 0, 3);
            this.mainLayout.Controls.Add(this.statusGroup, 3, 3);
            this.mainLayout.SetColumnSpan(this.commandsGroup, 3);
            this.mainLayout.SetColumnSpan(this.statusGroup, 2);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 4;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(800, 450);

            // connectButton
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectButton.Location = new System.Drawing.Point(603, 73);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);

            // txtNodeId
            this.txtNodeId.Location = new System.Drawing.Point(3, 43);
            this.txtNodeId.Name = "txtNodeId";
            this.txtNodeId.Size = new System.Drawing.Size(100, 20);
            this.txtNodeId.TabIndex = 1;
            this.txtNodeId.PlaceholderText = "Node ID";

            // txtState
            this.txtState.Location = new System.Drawing.Point(123, 43);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(100, 20);
            this.txtState.TabIndex = 2;
            this.txtState.PlaceholderText = "State";

            // txtSendCount
            this.txtSendCount.Location = new System.Drawing.Point(243, 43);
            this.txtSendCount.Name = "txtSendCount";
            this.txtSendCount.Size = new System.Drawing.Size(100, 20);
            this.txtSendCount.TabIndex = 3;
            this.txtSendCount.PlaceholderText = "Send Count";

            // txtReceiveCount
            this.txtReceiveCount.Location = new System.Drawing.Point(363, 43);
            this.txtReceiveCount.Name = "txtReceiveCount";
            this.txtReceiveCount.Size = new System.Drawing.Size(100, 20);
            this.txtReceiveCount.TabIndex = 4;
            this.txtReceiveCount.PlaceholderText = "Receive Count";

            // chkContinuously
            this.chkContinuously.Location = new System.Drawing.Point(3, 73);
            this.chkContinuously.Name = "chkContinuously";
            this.chkContinuously.Size = new System.Drawing.Size(100, 20);
            this.chkContinuously.TabIndex = 5;
            this.chkContinuously.Text = "Continuously";
            this.chkContinuously.UseVisualStyleBackColor = true;
            this.chkContinuously.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // chkAuto
            this.chkAuto.Location = new System.Drawing.Point(123, 73);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(50, 20);
            this.chkAuto.TabIndex = 6;
            this.chkAuto.Text = "Auto";
            this.chkAuto.UseVisualStyleBackColor = true;
            this.chkAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // commandsGroup
            this.commandsGroup.Location = new System.Drawing.Point(3, 103);
            this.commandsGroup.Name = "commandsGroup";
            this.commandsGroup.Size = new System.Drawing.Size(394, 344);
            this.commandsGroup.Text = "Commands (Send to device)";
            this.commandsGroup.Padding = new System.Windows.Forms.Padding(10);

            // statusGroup
            this.statusGroup.Location = new System.Drawing.Point(403, 103);
            this.statusGroup.Name = "statusGroup";
            this.statusGroup.Size = new System.Drawing.Size(394, 344);
            this.statusGroup.Text = "Status (Receive from device)";
            this.statusGroup.Padding = new System.Windows.Forms.Padding(10);

            // Form1
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainLayout);
            this.Name = "Form1";
            this.Text = "CAN Bus Communication";
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
