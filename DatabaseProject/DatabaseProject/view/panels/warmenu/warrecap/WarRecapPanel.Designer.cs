using DatabaseProject.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.view.panels.warmenu.warrecap
{
    public partial class WarRecapPanel
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
            clan1Label = new Label();
            clan2Label = new Label();
            vsLabel = new Label();
            label2 = new Label();
            clan1StarsLabel = new Label();
            clan2StarsLabel = new Label();
            label5 = new Label();
            clan1AverageLabel = new Label();
            clan2AverageLabel = new Label();
            victoryLabel = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // BackButton
            // 
            BackButton.Image = Resources.back_arrow;
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
            titleLabel.Size = new Size(226, 37);
            titleLabel.TabIndex = 2;
            titleLabel.Text = "Risultati di guerra";
            // 
            // clan1Label
            // 
            clan1Label.Dock = DockStyle.Fill;
            clan1Label.Font = new Font("Segoe UI", 12F);
            clan1Label.Location = new Point(5, 2);
            clan1Label.Name = "clan1Label";
            clan1Label.Size = new Size(171, 93);
            clan1Label.TabIndex = 4;
            clan1Label.Text = "Nome Clan 1";
            clan1Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // clan2Label
            // 
            clan2Label.Dock = DockStyle.Fill;
            clan2Label.Font = new Font("Segoe UI", 12F);
            clan2Label.Location = new Point(363, 2);
            clan2Label.Name = "clan2Label";
            clan2Label.Size = new Size(172, 93);
            clan2Label.TabIndex = 4;
            clan2Label.Text = "Nome Clan 2";
            clan2Label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // vsLabel
            // 
            vsLabel.Dock = DockStyle.Fill;
            vsLabel.Font = new Font("Impact", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            vsLabel.Location = new Point(184, 2);
            vsLabel.Name = "vsLabel";
            vsLabel.Size = new Size(171, 93);
            vsLabel.TabIndex = 5;
            vsLabel.Text = "vs";
            vsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Impact", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(184, 97);
            label2.Name = "label2";
            label2.Size = new Size(171, 93);
            label2.TabIndex = 5;
            label2.Text = "Stelle";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // clan1StarsLabel
            // 
            clan1StarsLabel.Dock = DockStyle.Fill;
            clan1StarsLabel.Font = new Font("Segoe UI", 12F);
            clan1StarsLabel.Location = new Point(5, 97);
            clan1StarsLabel.Name = "clan1StarsLabel";
            clan1StarsLabel.Size = new Size(171, 93);
            clan1StarsLabel.TabIndex = 4;
            clan1StarsLabel.Text = "Stelle Clan 1";
            clan1StarsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // clan2StarsLabel
            // 
            clan2StarsLabel.Dock = DockStyle.Fill;
            clan2StarsLabel.Font = new Font("Segoe UI", 12F);
            clan2StarsLabel.Location = new Point(363, 97);
            clan2StarsLabel.Name = "clan2StarsLabel";
            clan2StarsLabel.Size = new Size(172, 93);
            clan2StarsLabel.TabIndex = 4;
            clan2StarsLabel.Text = "Stelle Clan 2";
            clan2StarsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Impact", 18F, FontStyle.Bold | FontStyle.Italic);
            label5.Location = new Point(184, 192);
            label5.Name = "label5";
            label5.Size = new Size(171, 93);
            label5.TabIndex = 5;
            label5.Text = "Tempo medio";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // clan1AverageLabel
            // 
            clan1AverageLabel.Dock = DockStyle.Fill;
            clan1AverageLabel.Font = new Font("Segoe UI", 12F);
            clan1AverageLabel.Location = new Point(5, 192);
            clan1AverageLabel.Name = "clan1AverageLabel";
            clan1AverageLabel.Size = new Size(171, 93);
            clan1AverageLabel.TabIndex = 4;
            clan1AverageLabel.Text = "Tempo medio clan 1";
            clan1AverageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // clan2AverageLabel
            // 
            clan2AverageLabel.Dock = DockStyle.Fill;
            clan2AverageLabel.Font = new Font("Segoe UI", 12F);
            clan2AverageLabel.Location = new Point(363, 192);
            clan2AverageLabel.Name = "clan2AverageLabel";
            clan2AverageLabel.Size = new Size(172, 93);
            clan2AverageLabel.TabIndex = 4;
            clan2AverageLabel.Text = "Tempo medio clan 2";
            clan2AverageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // victoryLabel
            // 
            victoryLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(victoryLabel, 3);
            victoryLabel.Font = new Font("Impact", 27.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 186);
            victoryLabel.ForeColor = Color.FromArgb(192, 0, 0);
            victoryLabel.Location = new Point(5, 287);
            victoryLabel.Name = "victoryLabel";
            victoryLabel.Size = new Size(530, 51);
            victoryLabel.TabIndex = 5;
            victoryLabel.Text = "Vittoria: Nome Clan";
            victoryLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel1.Controls.Add(clan1Label, 0, 0);
            tableLayoutPanel1.Controls.Add(victoryLabel, 0, 3);
            tableLayoutPanel1.Controls.Add(vsLabel, 1, 0);
            tableLayoutPanel1.Controls.Add(clan2AverageLabel, 2, 2);
            tableLayoutPanel1.Controls.Add(label5, 1, 2);
            tableLayoutPanel1.Controls.Add(clan2Label, 2, 0);
            tableLayoutPanel1.Controls.Add(label2, 1, 1);
            tableLayoutPanel1.Controls.Add(clan1AverageLabel, 0, 2);
            tableLayoutPanel1.Controls.Add(clan2StarsLabel, 2, 1);
            tableLayoutPanel1.Controls.Add(clan1StarsLabel, 0, 1);
            tableLayoutPanel1.Location = new Point(37, 107);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(540, 340);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // WarRecapPanel
            // 
            Controls.Add(tableLayoutPanel1);
            Controls.Add(titleLabel);
            Controls.Add(BackButton);
            Name = "WarRecapPanel";
            Size = new Size(615, 479);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private Button BackButton;
        private Label titleLabel;
        private Label clan1Label;
        private Label clan2Label;
        private Label vsLabel;
        private Label label2;
        private Label clan1StarsLabel;
        private Label clan2StarsLabel;
        private Label label5;
        private Label clan1AverageLabel;
        private Label clan2AverageLabel;
        private Label victoryLabel;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
