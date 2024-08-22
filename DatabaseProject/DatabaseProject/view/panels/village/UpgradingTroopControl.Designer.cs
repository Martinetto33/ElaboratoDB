namespace DatabaseProject.view.panels.village
{
    partial class UpgradingTroopControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            displayedStringLabel = new Label();
            progressBar1 = new ProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            timeLabel = new Label();
            SuspendLayout();
            // 
            // displayedStringLabel
            // 
            displayedStringLabel.AutoSize = true;
            displayedStringLabel.Location = new Point(18, 12);
            displayedStringLabel.Name = "displayedStringLabel";
            displayedStringLabel.Size = new Size(0, 15);
            displayedStringLabel.TabIndex = 0;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(18, 36);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(303, 10);
            progressBar1.Step = 1;
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 1;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Location = new Point(327, 34);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(133, 15);
            timeLabel.TabIndex = 2;
            timeLabel.Text = "Tempo rimanente: 00:00";
            // 
            // UpgradingBuildingControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(timeLabel);
            Controls.Add(progressBar1);
            Controls.Add(displayedStringLabel);
            Name = "UpgradingBuildingControl";
            Size = new Size(481, 73);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label displayedStringLabel;
        private ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private Label timeLabel;
    }
}
