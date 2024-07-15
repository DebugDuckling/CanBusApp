using System;
using System.Drawing;
using System.Windows.Forms;

namespace CanBusApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Button connectButton;
        private TextBox txtNodeId;
        private TextBox txtRecons;
        private TextBox txtTxState;
        private TextBox txtTxFrames;
        private TextBox txtRxFrames;
        private CheckBox chkTxContinuous;
        private CheckBox chkAutoUpdate;
        private Label lblTitle;
        private TableLayoutPanel mainLayout;
        private TableLayoutPanel topLayout;
        private TableLayoutPanel bottomLayout;
        private GroupBox commandsGroup;
        private GroupBox statusGroup;
        private GroupBox arcnetGroup;
        private GroupBox optionsGroup;
        private Button updateButton;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.connectButton = new Button();
            this.txtNodeId = new TextBox();
            this.txtRecons = new TextBox();
            this.txtTxState = new TextBox();
            this.txtTxFrames = new TextBox();
            this.txtRxFrames = new TextBox();
            this.chkTxContinuous = new CheckBox();
            this.chkAutoUpdate = new CheckBox();
            this.lblTitle = new Label();
            this.mainLayout = new TableLayoutPanel();
            this.topLayout = new TableLayoutPanel();
            this.bottomLayout = new TableLayoutPanel();
            this.commandsGroup = new GroupBox();
            this.statusGroup = new GroupBox();
            this.arcnetGroup = new GroupBox();
            this.optionsGroup = new GroupBox();
            this.updateButton = new Button();

            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.Text = "CAN Bus Communication";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // mainLayout
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.lblTitle, 0, 0);
            this.mainLayout.Controls.Add(this.topLayout, 0, 1);
            this.mainLayout.Controls.Add(this.bottomLayout, 0, 2);
            this.mainLayout.Dock = DockStyle.Fill;
            this.mainLayout.Location = new Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 3;
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.mainLayout.Size = new Size(800, 450);

            // topLayout
            this.topLayout.ColumnCount = 2;
            this.topLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            this.topLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            this.topLayout.Controls.Add(this.arcnetGroup, 0, 0);
            this.topLayout.Controls.Add(this.optionsGroup, 1, 0);
            this.topLayout.Dock = DockStyle.Fill;
            this.topLayout.Location = new Point(3, 43);
            this.topLayout.Name = "topLayout";
            this.topLayout.RowCount = 1;
            this.topLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.topLayout.Size = new Size(794, 199);

            // bottomLayout
            this.bottomLayout.ColumnCount = 2;
            this.bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            this.bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            this.bottomLayout.Controls.Add(this.commandsGroup, 0, 0);
            this.bottomLayout.Controls.Add(this.statusGroup, 1, 0);
            this.bottomLayout.Dock = DockStyle.Fill;
            this.bottomLayout.Location = new Point(3, 248);
            this.bottomLayout.Name = "bottomLayout";
            this.bottomLayout.RowCount = 1;
            this.bottomLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.bottomLayout.Size = new Size(794, 199);

            // arcnetGroup
            this.arcnetGroup.Controls.Add(this.txtNodeId);
            this.arcnetGroup.Controls.Add(this.txtRecons);
            this.arcnetGroup.Controls.Add(this.txtTxState);
            this.arcnetGroup.Controls.Add(this.txtTxFrames);
            this.arcnetGroup.Controls.Add(this.txtRxFrames);
            this.arcnetGroup.Controls.Add(this.connectButton);
            this.arcnetGroup.Dock = DockStyle.Fill;
            this.arcnetGroup.Location = new Point(3, 3);
            this.arcnetGroup.Name = "arcnetGroup";
            this.arcnetGroup.Size = new Size(629, 193);
            this.arcnetGroup.Text = "ARCNET";

            // txtNodeId
            this.txtNodeId.Location = new Point(20, 30);
            this.txtNodeId.Name = "txtNodeId";
            this.txtNodeId.Size = new Size(100, 20);
            this.txtNodeId.TabIndex = 1;
            this.txtNodeId.PlaceholderText = "Node ID";

            // txtRecons
            this.txtRecons.Location = new Point(140, 30);
            this.txtRecons.Name = "txtRecons";
            this.txtRecons.Size = new Size(100, 20);
            this.txtRecons.TabIndex = 2;
            this.txtRecons.PlaceholderText = "Recons";

            // txtTxState
            this.txtTxState.Location = new Point(260, 30);
            this.txtTxState.Name = "txtTxState";
            this.txtTxState.Size = new Size(100, 20);
            this.txtTxState.TabIndex = 3;
            this.txtTxState.PlaceholderText = "TX State";

            // txtTxFrames
            this.txtTxFrames.Location = new Point(380, 30);
            this.txtTxFrames.Name = "txtTxFrames";
            this.txtTxFrames.Size = new Size(100, 20);
            this.txtTxFrames.TabIndex = 4;
            this.txtTxFrames.PlaceholderText = "TX Frames";

            // txtRxFrames
            this.txtRxFrames.Location = new Point(500, 30);
            this.txtRxFrames.Name = "txtRxFrames";
            this.txtRxFrames.Size = new Size(100, 20);
            this.txtRxFrames.TabIndex = 5;
            this.txtRxFrames.PlaceholderText = "RX Frames";

            // connectButton
            this.connectButton.FlatStyle = FlatStyle.Flat;
            this.connectButton.Location = new Point(260, 60);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new Size(75, 23);
            this.connectButton.TabIndex = 6;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);

            // optionsGroup
            this.optionsGroup.Controls.Add(this.chkTxContinuous);
            this.optionsGroup.Controls.Add(this.chkAutoUpdate);
            this.optionsGroup.Controls.Add(this.updateButton);
            this.optionsGroup.Dock = DockStyle.Fill;
            this.optionsGroup.Location = new Point(638, 3);
            this.optionsGroup.Name = "optionsGroup";
            this.optionsGroup.Size = new Size(153, 193);
            this.optionsGroup.Text = "Options";

            // chkTxContinuous
            this.chkTxContinuous.Location = new Point(20, 30);
            this.chkTxContinuous.Name = "chkTxContinuous";
            this.chkTxContinuous.Size = new Size(120, 20);
            this.chkTxContinuous.TabIndex = 7;
            this.chkTxContinuous.Text = "TX Continuous";
            this.chkTxContinuous.UseVisualStyleBackColor = true;
            this.chkTxContinuous.FlatStyle = FlatStyle.Flat;

            // chkAutoUpdate
            this.chkAutoUpdate.Location = new Point(20, 60);
            this.chkAutoUpdate.Name = "chkAutoUpdate";
            this.chkAutoUpdate.Size = new Size(120, 20);
            this.chkAutoUpdate.TabIndex = 8;
            this.chkAutoUpdate.Text = "Auto Update";
            this.chkAutoUpdate.UseVisualStyleBackColor = true;
            this.chkAutoUpdate.FlatStyle = FlatStyle.Flat;

            // updateButton
            this.updateButton.FlatStyle = FlatStyle.Flat;
            this.updateButton.Location = new Point(20, 90);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new Size(75, 23);
            this.updateButton.TabIndex = 9;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);

            // commandsGroup
            this.commandsGroup.Dock = DockStyle.Fill;
            this.commandsGroup.Location = new Point(3, 3);
            this.commandsGroup.Name = "commandsGroup";
            this.commandsGroup.Size = new Size(634, 193);
            this.commandsGroup.Text = "Commands (Send to device)";

            // statusGroup
            this.statusGroup.Dock = DockStyle.Fill;
            this.statusGroup.Location = new Point(643, 3);
            this.statusGroup.Name = "statusGroup";
            this.statusGroup.Size = new Size(148, 193);
            this.statusGroup.Text = "Status (Receive from device)";

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