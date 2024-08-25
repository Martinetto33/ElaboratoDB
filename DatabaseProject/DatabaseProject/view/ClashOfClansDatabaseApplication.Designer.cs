using DatabaseProject.view.panels;
using DatabaseProject.view.panels.initialmenu;

namespace DatabaseProject
{
    partial class ClashOfClansDatabaseApplication
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            Controls.Add(new InitialMenuPanel());
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 461);
            MinimumSize = new Size(600, 500);
            Name = "InitialMenu";
            Text = "Clash of Clans Database";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

    }
}
