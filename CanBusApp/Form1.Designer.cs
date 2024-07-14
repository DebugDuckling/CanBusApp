using System;

namespace CanBusApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Button connectButton;
        private Button closeButton;
        private Button updateButton;
        private TextBox txtNodeId;
        private TextBox txtRecons;
        private TextBox txtTxState;
        private TextBox txtTxFrames;
        private TextBox txtRxFrames;
        private CheckBox chkTxContinuous;
        private CheckBox chkAutoUpdate;
        private Label lblTitle;
        private TableLayoutPanel mainLayout;
        private GroupBox arcnetGroup;
        private GroupBox commandsGroup;
        private GroupBox statusGroup;
        private GroupBox optionsGroup;
        private Label lblNodeId;
        private Label lblRecons;
        private Label lblTxState;
        private Label lblTxFrames;
        private Label lblRxFrames;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.connectButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.txtNodeId = new System.Windows.Forms.TextBox();
            this.txtRecons = new System.Windows.Forms.TextBox();
            this.txtTxState = new System.Windows.Forms.TextBox();
            this.txtTxFrames = new System.Windows.Forms.TextBox();
            this.txtRxFrames = new System.Windows.Forms.TextBox();
            this.chkTxContinuous = new System.Windows.Forms.CheckBox();
            this.chkAutoUpdate = new System.Windows.Forms.CheckBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.arcnetGroup = new System.Windows.Forms.GroupBox();
            this.commandsGroup = new System.Windows.Forms.GroupBox();
            this.statusGroup = new System.Windows.Forms.GroupBox();
            this.optionsGroup = new System.Windows.Forms.GroupBox();
            this.lblNodeId = new System.Windows.Forms.Label();
            this.lblRecons = new System.Windows.Forms.Label();
            this.lblTxState = new System.Windows.Forms.Label();
            this.lblTxFrames = new System.Windows.Forms.Label();
            this.lblRxFrames = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Text = "ARCNET Simulator";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // mainLayout
            this.mainLayout.ColumnCount = 6;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mainLayout.Controls.Add(this.lblTitle, 0, 0);
            this.mainLayout.SetColumnSpan(this.lblTitle, 6);
            this.mainLayout.Controls.Add(this.arcnetGroup, 0, 1);
            this.mainLayout.SetColumnSpan(this.arcnetGroup, 3);
            this.mainLayout.Controls.Add(this.optionsGroup, 3, 1);
            this.mainLayout.SetColumnSpan(this.optionsGroup, 3);
            this.mainLayout.Controls.Add(this.commandsGroup, 0, 2);
            this.mainLayout.Controls.Add(this.statusGroup, 3, 2);
            this.mainLayout.SetColumnSpan(this.commandsGroup, 3);
            this.mainLayout.SetColumnSpan(this.statusGroup, 3);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 3;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(800, 450);

            // arcnetGroup
            this.arcnetGroup.Controls.Add(this.lblNodeId);
            this.arcnetGroup.Controls.Add(this.txtNodeId);
            this.arcnetGroup.Controls.Add(this.lblRecons);
            this.arcnetGroup.Controls.Add(this.txtRecons);
            this.arcnetGroup.Controls.Add(this.lblTxState);
            this.arcnetGroup.Controls.Add(this.txtTxState);
            this.arcnetGroup.Controls.Add(this.lblTxFrames);
            this.arcnetGroup.Controls.Add(this.txtTxFrames);
            this.arcnetGroup.Controls.Add(this.lblRxFrames);
            this.arcnetGroup.Controls.Add(this.txtRxFrames);
            this.arcnetGroup.Controls.Add(this.connectButton);
            this.arcnetGroup.Controls.Add(this.closeButton);
            this.arcnetGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.arcnetGroup.Location = new System.Drawing.Point(3, 43);
            this.arcnetGroup.Name = "arcnetGroup";
            this.arcnetGroup.Size = new System.Drawing.Size(394, 144); // Adjusted size to fit next to optionsGroup
            this.arcnetGroup.TabIndex = 0;
            this.arcnetGroup.TabStop = false;
            this.arcnetGroup.Text = "ARCNET";

            // lblNodeId
            this.lblNodeId.Location = new System.Drawing.Point(10, 20);
            this.lblNodeId.Name = "lblNodeId";
            this.lblNodeId.Size = new System.Drawing.Size(100, 20);
            this.lblNodeId.Text = "Node Id";

            // txtNodeId
            this.txtNodeId.Location = new System.Drawing.Point(10, 40);
            this.txtNodeId.Name = "txtNodeId";
            this.txtNodeId.Size = new System.Drawing.Size(100, 20);
            this.txtNodeId.TabIndex = 1;

            // lblRecons
            this.lblRecons.Location = new System.Drawing.Point(120, 20);
            this.lblRecons.Name = "lblRecons";
            this.lblRecons.Size = new System.Drawing.Size(100, 20);
            this.lblRecons.Text = "Recons";

            // txtRecons
            this.txtRecons.Location = new System.Drawing.Point(120, 40);
            this.txtRecons.Name = "txtRecons";
            this.txtRecons.Size = new System.Drawing.Size(100, 20);
            this.txtRecons.TabIndex = 2;

            // lblTxState
            this.lblTxState.Location = new System.Drawing.Point(230, 20);
            this.lblTxState.Name = "lblTxState";
            this.lblTxState.Size = new System.Drawing.Size(100, 20);
            this.lblTxState.Text = "TX State";

            // txtTxState
            this.txtTxState.Location = new System.Drawing.Point(230, 40);
            this.txtTxState.Name = "txtTxState";
            this.txtTxState.Size = new System.Drawing.Size(100, 20);
            this.txtTxState.TabIndex = 3;

            // lblTxFrames
            this.lblTxFrames.Location = new System.Drawing.Point(340, 20);
            this.lblTxFrames.Name = "lblTxFrames";
            this.lblTxFrames.Size = new System.Drawing.Size(100, 20);
            this.lblTxFrames.Text = "TX Frames";

            // txtTxFrames
            this.txtTxFrames.Location = new System.Drawing.Point(340, 40);
            this.txtTxFrames.Name = "txtTxFrames";
            this.txtTxFrames.Size = new System.Drawing.Size(100, 20);
            this.txtTxFrames.TabIndex = 4;

            // lblRxFrames
            this.lblRxFrames.Location = new System.Drawing.Point(450, 20);
            this.lblRxFrames.Name = "lblRxFrames";
            this.lblRxFrames.Size = new System.Drawing.Size(100, 20);
            this.lblRxFrames.Text = "RX Frames";

            // txtRxFrames
            this.txtRxFrames.Location = new System.Drawing.Point(450, 40);
            this.txtRxFrames.Name = "txtRxFrames";
            this.txtRxFrames.Size = new System.Drawing.Size(100, 20);
            this.txtRxFrames.TabIndex = 5;

            // connectButton
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectButton.Location = new System.Drawing.Point(10, 70);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 6;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;

            // closeButton
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Location = new System.Drawing.Point(90, 70);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 7;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;

            // optionsGroup
            this.optionsGroup.Controls.Add(this.chkTxContinuous);
            this.optionsGroup.Controls.Add(this.chkAutoUpdate);
            this.optionsGroup.Controls.Add(this.updateButton);
            this.optionsGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsGroup.Location = new System.Drawing.Point(403, 43);
            this.optionsGroup.Name = "optionsGroup";
            this.optionsGroup.Size = new System.Drawing.Size(394, 144); // Adjusted size to fit next to arcnetGroup
            this.optionsGroup.TabIndex = 1;
            this.optionsGroup.TabStop = false;
            this.optionsGroup.Text = "Options";

            // chkTxContinuous
            this.chkTxContinuous.Location = new System.Drawing.Point(10, 20);
            this.chkTxContinuous.Name = "chkTxContinuous";
            this.chkTxContinuous.Size = new System.Drawing.Size(100, 20);
            this.chkTxContinuous.TabIndex = 0;
            this.chkTxContinuous.Text = "TX Continuous";
            this.chkTxContinuous.UseVisualStyleBackColor = true;

            // chkAutoUpdate
            this.chkAutoUpdate.Location = new System.Drawing.Point(10, 50);
            this.chkAutoUpdate.Name = "chkAutoUpdate";
            this.chkAutoUpdate.Size = new System.Drawing.Size(100, 20);
            this.chkAutoUpdate.TabIndex = 1;
            this.chkAutoUpdate.Text = "Auto Update";
            this.chkAutoUpdate.UseVisualStyleBackColor = true;

            // updateButton
            this.updateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateButton.Location = new System.Drawing.Point(10, 80);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;

            // commandsGroup
            this.commandsGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandsGroup.Location = new System.Drawing.Point(3, 193);
            this.commandsGroup.Name = "commandsGroup";
            this.commandsGroup.Size = new System.Drawing.Size(394, 254);
            this.commandsGroup.TabIndex = 2;
            this.commandsGroup.TabStop = false;
            this.commandsGroup.Text = "Commands";

            // statusGroup
            this.statusGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusGroup.Location = new System.Drawing.Point(403, 193);
            this.statusGroup.Name = "statusGroup";
            this.statusGroup.Size = new System.Drawing.Size(394, 254);
            this.statusGroup.TabIndex = 3;
            this.statusGroup.TabStop = false;
            this.statusGroup.Text = "Status";

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