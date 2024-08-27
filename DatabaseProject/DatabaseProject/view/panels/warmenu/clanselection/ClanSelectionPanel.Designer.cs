using DatabaseProject.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.view.panels.warmenu.clanselection
{
    public partial class ClanSelectionPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            BackButton = new Button();
            titleLabel = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            clansGroupBox = new GroupBox();
            unselectedClanLabelsFlowLayoutPanel = new FlowLayoutPanel();
            confirmButton = new Button();
            clansGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // BackButton
            // 
            BackButton.BackgroundImage = Resources.back_arrow;
            BackButton.BackgroundImageLayout = ImageLayout.Zoom;
            BackButton.Location = new Point(18, 12);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(50, 50);
            BackButton.TabIndex = 1;
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 20F);
            titleLabel.Location = new Point(88, 12);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(207, 37);
            titleLabel.TabIndex = 2;
            titleLabel.Text = "Seleziona 2 clan";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.BackColor = Color.FromArgb(255, 192, 128);
            flowLayoutPanel1.Location = new Point(38, 90);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(509, 75);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(38, 68);
            label1.Name = "label1";
            label1.Size = new Size(118, 21);
            label1.TabIndex = 4;
            label1.Text = "Clan selezionati";
            // 
            // clansGroupBox
            // 
            clansGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            clansGroupBox.Controls.Add(unselectedClanLabelsFlowLayoutPanel);
            clansGroupBox.Location = new Point(38, 171);
            clansGroupBox.Name = "clansGroupBox";
            clansGroupBox.Size = new Size(509, 237);
            clansGroupBox.TabIndex = 5;
            clansGroupBox.TabStop = false;
            clansGroupBox.Text = "Clan disponibili";
            // 
            // unselectedClanLabelsFlowLayoutPanel
            // 
            unselectedClanLabelsFlowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            unselectedClanLabelsFlowLayoutPanel.Location = new Point(3, 19);
            unselectedClanLabelsFlowLayoutPanel.Name = "unselectedClanLabelsFlowLayoutPanel";
            unselectedClanLabelsFlowLayoutPanel.Size = new Size(503, 215);
            unselectedClanLabelsFlowLayoutPanel.TabIndex = 0;
            // 
            // confirmButton
            // 
            confirmButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            confirmButton.BackColor = Color.FromArgb(0, 192, 0);
            confirmButton.ForeColor = SystemColors.ButtonFace;
            confirmButton.Location = new Point(395, 421);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(151, 32);
            confirmButton.TabIndex = 6;
            confirmButton.Text = "Conferma";
            confirmButton.UseVisualStyleBackColor = false;
            confirmButton.Click += ConfirmButton_Click;
            // 
            // ClanSelectionPanel
            // 
            Controls.Add(confirmButton);
            Controls.Add(clansGroupBox);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(titleLabel);
            Controls.Add(BackButton);
            Name = "ClanSelectionPanel";
            Size = new Size(584, 461);
            clansGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private Button BackButton;
        private Label titleLabel;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private GroupBox clansGroupBox;
        private Button confirmButton;
        private FlowLayoutPanel unselectedClanLabelsFlowLayoutPanel;
    }
}
