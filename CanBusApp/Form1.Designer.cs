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
            connectButton = new Button();
            txtNodeId = new TextBox();
            txtRecons = new TextBox();
            txtTxState = new TextBox();
            txtTxFrames = new TextBox();
            txtRxFrames = new TextBox();
            chkTxContinuous = new CheckBox();
            chkAutoUpdate = new CheckBox();
            lblTitle = new Label();
            mainLayout = new TableLayoutPanel();
            topLayout = new TableLayoutPanel();
            arcnetGroup = new GroupBox();
            optionsGroup = new GroupBox();
            updateButton = new Button();
            bottomLayout = new TableLayoutPanel();
            commandsGroup = new GroupBox();
            statusGroup = new GroupBox();
            mainLayout.SuspendLayout();
            topLayout.SuspendLayout();
            arcnetGroup.SuspendLayout();
            optionsGroup.SuspendLayout();
            bottomLayout.SuspendLayout();
            SuspendLayout();
            // 
            // connectButton
            // 
            connectButton.FlatStyle = FlatStyle.Flat;
            connectButton.Location = new Point(632, 30);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(75, 23);
            connectButton.TabIndex = 6;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // txtNodeId
            // 
            txtNodeId.Location = new Point(20, 30);
            txtNodeId.Name = "txtNodeId";
            txtNodeId.PlaceholderText = "Node ID";
            txtNodeId.Size = new Size(100, 23);
            txtNodeId.TabIndex = 1;
            // 
            // txtRecons
            // 
            txtRecons.Location = new Point(140, 30);
            txtRecons.Name = "txtRecons";
            txtRecons.PlaceholderText = "Recons";
            txtRecons.Size = new Size(100, 23);
            txtRecons.TabIndex = 2;
            // 
            // txtTxState
            // 
            txtTxState.Location = new Point(260, 30);
            txtTxState.Name = "txtTxState";
            txtTxState.PlaceholderText = "TX State";
            txtTxState.Size = new Size(100, 23);
            txtTxState.TabIndex = 3;
            // 
            // txtTxFrames
            // 
            txtTxFrames.Location = new Point(380, 30);
            txtTxFrames.Name = "txtTxFrames";
            txtTxFrames.PlaceholderText = "TX Frames";
            txtTxFrames.Size = new Size(100, 23);
            txtTxFrames.TabIndex = 4;
            // 
            // txtRxFrames
            // 
            txtRxFrames.Location = new Point(500, 30);
            txtRxFrames.Name = "txtRxFrames";
            txtRxFrames.PlaceholderText = "RX Frames";
            txtRxFrames.Size = new Size(100, 23);
            txtRxFrames.TabIndex = 5;
            // 
            // chkTxContinuous
            // 
            chkTxContinuous.FlatStyle = FlatStyle.Flat;
            chkTxContinuous.Location = new Point(20, 30);
            chkTxContinuous.Name = "chkTxContinuous";
            chkTxContinuous.Size = new Size(120, 20);
            chkTxContinuous.TabIndex = 7;
            chkTxContinuous.Text = "TX Continuous";
            chkTxContinuous.UseVisualStyleBackColor = true;
            // 
            // chkAutoUpdate
            // 
            chkAutoUpdate.FlatStyle = FlatStyle.Flat;
            chkAutoUpdate.Location = new Point(20, 60);
            chkAutoUpdate.Name = "chkAutoUpdate";
            chkAutoUpdate.Size = new Size(120, 20);
            chkAutoUpdate.TabIndex = 8;
            chkAutoUpdate.Text = "Auto Update";
            chkAutoUpdate.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(3, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(932, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "CAN Bus Communication";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.Controls.Add(lblTitle, 0, 0);
            mainLayout.Controls.Add(topLayout, 0, 1);
            mainLayout.Controls.Add(bottomLayout, 0, 2);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 3;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 31.6239319F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 68.37607F));
            mainLayout.Size = new Size(938, 508);
            mainLayout.TabIndex = 0;
            // 
            // topLayout
            // 
            topLayout.ColumnCount = 2;
            topLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            topLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            topLayout.Controls.Add(arcnetGroup, 0, 0);
            topLayout.Controls.Add(optionsGroup, 1, 0);
            topLayout.Dock = DockStyle.Fill;
            topLayout.Location = new Point(3, 43);
            topLayout.Name = "topLayout";
            topLayout.RowCount = 1;
            topLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            topLayout.Size = new Size(932, 142);
            topLayout.TabIndex = 1;
            // 
            // arcnetGroup
            // 
            arcnetGroup.Controls.Add(txtNodeId);
            arcnetGroup.Controls.Add(txtRecons);
            arcnetGroup.Controls.Add(txtTxState);
            arcnetGroup.Controls.Add(txtTxFrames);
            arcnetGroup.Controls.Add(txtRxFrames);
            arcnetGroup.Controls.Add(connectButton);
            arcnetGroup.Dock = DockStyle.Fill;
            arcnetGroup.Location = new Point(3, 3);
            arcnetGroup.Name = "arcnetGroup";
            arcnetGroup.Size = new Size(739, 136);
            arcnetGroup.TabIndex = 0;
            arcnetGroup.TabStop = false;
            arcnetGroup.Text = "ARCNET";
            // 
            // optionsGroup
            // 
            optionsGroup.Controls.Add(chkTxContinuous);
            optionsGroup.Controls.Add(chkAutoUpdate);
            optionsGroup.Controls.Add(updateButton);
            optionsGroup.Dock = DockStyle.Fill;
            optionsGroup.Location = new Point(748, 3);
            optionsGroup.Name = "optionsGroup";
            optionsGroup.Size = new Size(181, 136);
            optionsGroup.TabIndex = 1;
            optionsGroup.TabStop = false;
            optionsGroup.Text = "Options";
            // 
            // updateButton
            // 
            updateButton.FlatStyle = FlatStyle.Flat;
            updateButton.Location = new Point(20, 90);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(75, 23);
            updateButton.TabIndex = 9;
            updateButton.Text = "Update";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;
            // 
            // bottomLayout
            // 
            bottomLayout.ColumnCount = 2;
            bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            bottomLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            bottomLayout.Controls.Add(commandsGroup, 0, 0);
            bottomLayout.Controls.Add(statusGroup, 1, 0);
            bottomLayout.Dock = DockStyle.Fill;
            bottomLayout.Location = new Point(3, 191);
            bottomLayout.Name = "bottomLayout";
            bottomLayout.RowCount = 1;
            bottomLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            bottomLayout.Size = new Size(932, 314);
            bottomLayout.TabIndex = 2;
            // 
            // commandsGroup
            // 
            commandsGroup.Dock = DockStyle.Fill;
            commandsGroup.Location = new Point(3, 3);
            commandsGroup.Name = "commandsGroup";
            commandsGroup.Size = new Size(460, 308);
            commandsGroup.TabIndex = 0;
            commandsGroup.TabStop = false;
            commandsGroup.Text = "Commands (Send to device)";
            // 
            // statusGroup
            // 
            statusGroup.Dock = DockStyle.Fill;
            statusGroup.Location = new Point(469, 3);
            statusGroup.Name = "statusGroup";
            statusGroup.Size = new Size(460, 308);
            statusGroup.TabIndex = 1;
            statusGroup.TabStop = false;
            statusGroup.Text = "Status (Receive from device)";
            // 
            // Form1
            // 
            ClientSize = new Size(938, 508);
            Controls.Add(mainLayout);
            Name = "Form1";
            Text = "CAN Bus Communication";
            mainLayout.ResumeLayout(false);
            topLayout.ResumeLayout(false);
            arcnetGroup.ResumeLayout(false);
            arcnetGroup.PerformLayout();
            optionsGroup.ResumeLayout(false);
            bottomLayout.ResumeLayout(false);
            ResumeLayout(false);
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