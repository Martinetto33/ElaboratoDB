﻿namespace DatabaseProject
{
    partial class InitialMenu
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
            ExitButton = new Button();
            PlayersButton = new Button();
            ClansButton = new Button();
            WarsButton = new Button();
            panelContainer = new Panel();
            SuspendLayout();
            // 
            // ExitButton
            // 
            ExitButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ExitButton.Font = new Font("Segoe UI", 15F);
            ExitButton.Location = new Point(156, 332);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(409, 77);
            ExitButton.TabIndex = 0;
            ExitButton.Text = "Esci";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += exitButton_Click;
            // 
            // PlayersButton
            // 
            PlayersButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PlayersButton.Font = new Font("Segoe UI", 15F);
            PlayersButton.Location = new Point(156, 41);
            PlayersButton.Name = "PlayersButton";
            PlayersButton.Size = new Size(409, 77);
            PlayersButton.TabIndex = 1;
            PlayersButton.Text = "Giocatori";
            PlayersButton.UseVisualStyleBackColor = true;
            PlayersButton.Click += playersButton_Click;
            // 
            // ClansButton
            // 
            ClansButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ClansButton.Font = new Font("Segoe UI", 15F);
            ClansButton.Location = new Point(156, 138);
            ClansButton.Name = "ClansButton";
            ClansButton.Size = new Size(409, 77);
            ClansButton.TabIndex = 2;
            ClansButton.Text = "Clan";
            ClansButton.UseVisualStyleBackColor = true;
            ClansButton.Click += clansButton_Click;
            // 
            // WarsButton
            // 
            WarsButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            WarsButton.Font = new Font("Segoe UI", 15F);
            WarsButton.Location = new Point(156, 235);
            WarsButton.Name = "WarsButton";
            WarsButton.Size = new Size(409, 77);
            WarsButton.TabIndex = 3;
            WarsButton.Text = "Guerre";
            WarsButton.UseVisualStyleBackColor = true;
            WarsButton.Click += warsButton_Click;
            // 
            // panelContainer
            // 
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(720, 461);
            panelContainer.TabIndex = 4;
            // 
            // InitialMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 461);
            Controls.Add(panelContainer);
            MinimumSize = new Size(600, 500);
            Name = "InitialMenu";
            Text = "Clash of Clans Database";
            Load += Form1_Load;
            ResumeLayout(false);

            // Add buttons to the panelContainer
            panelContainer.Controls.Add(ExitButton);
            panelContainer.Controls.Add(PlayersButton);
            panelContainer.Controls.Add(ClansButton);
            panelContainer.Controls.Add(WarsButton);

            // Setting the panelContainer as the parent panel
            if (this.PanelContainer == null)
            {
                this.PanelContainer = panelContainer;
            }
        }

        #endregion

        private Button ExitButton;
        private Button PlayersButton;
        private Button ClansButton;
        private Button WarsButton;
        private Panel panelContainer;
    }
}
