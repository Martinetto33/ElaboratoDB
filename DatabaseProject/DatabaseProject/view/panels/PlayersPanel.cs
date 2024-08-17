﻿using DatabaseProject.daos;
using DatabaseProject.database;
using DatabaseProject.model;
using DatabaseProject.Properties;

namespace DatabaseProject.view.panels
{
    internal class PlayersPanel : UserControl
    {
        public PlayersPanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayersPanel));
            AddPlayerButton = new Button();
            BackButton = new Button();
            textBox1 = new TextBox();
            searchPlayerLabel = new Label();
            playerNamesPanel = new Panel();
            SuspendLayout();
            // 
            // AddPlayerButton
            // 
            AddPlayerButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AddPlayerButton.Location = new Point(108, 26);
            AddPlayerButton.Name = "AddPlayerButton";
            AddPlayerButton.Size = new Size(645, 93);
            AddPlayerButton.TabIndex = 0;
            AddPlayerButton.Text = "Aggiungi Giocatore [Test]";
            AddPlayerButton.UseVisualStyleBackColor = true;
            AddPlayerButton.Click += AddPlayerButton_Click;
            // 
            // BackButton
            // 
            BackButton.Image = (Image)resources.GetObject("BackButton.Image");
            BackButton.Location = new Point(12, 12);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(50, 50);
            BackButton.TabIndex = 1;
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Cursor = Cursors.IBeam;
            textBox1.Font = new Font("Segoe UI", 16F);
            textBox1.Location = new Point(108, 165);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Inserisci il nome del giocatore...";
            textBox1.Size = new Size(645, 36);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // searchPlayerLabel
            // 
            searchPlayerLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchPlayerLabel.AutoSize = true;
            searchPlayerLabel.Font = new Font("Segoe UI", 12F);
            searchPlayerLabel.Location = new Point(107, 135);
            searchPlayerLabel.Name = "searchPlayerLabel";
            searchPlayerLabel.Size = new Size(118, 21);
            searchPlayerLabel.TabIndex = 3;
            searchPlayerLabel.Text = "Cerca giocatore";
            searchPlayerLabel.Click += label1_Click;
            // 
            // playerNamesPanel
            // 
            playerNamesPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            playerNamesPanel.AutoScroll = true;
            playerNamesPanel.BackColor = Color.White;
            playerNamesPanel.BorderStyle = BorderStyle.FixedSingle;
            playerNamesPanel.Location = new Point(108, 231);
            playerNamesPanel.Name = "playerNamesPanel";
            playerNamesPanel.Padding = new Padding(10);
            playerNamesPanel.Size = new Size(645, 323);
            playerNamesPanel.TabIndex = 4;
            // 
            // PlayersPanel
            // 
            Controls.Add(AddPlayerButton);
            Controls.Add(BackButton);
            Controls.Add(textBox1);
            Controls.Add(searchPlayerLabel);
            Controls.Add(playerNamesPanel);
            Name = "PlayersPanel";
            Size = new Size(860, 560);
            ResumeLayout(false);
            PerformLayout();
        }

        private void AddPlayerButton_Click(object sender, EventArgs e)
        {
            PlayerDao.CreatePlayer("Alin", "Bordeianu");
            Console.WriteLine("Player added");
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var mainForm = (ClashOfClansDatabaseApplication)this.ParentForm!;
            mainForm.LoadPanel(new InitialMenuPanel());
        }

        private void LoadPlayerButtons(Panel playerNamesPanel)
        {
            List<Giocatore> players = PlayerDao.GetAllPlayers();
            playerNamesPanel.Controls.Clear();

            int yOffset = 10;
            foreach (var player in players)
            {
                Button playerButton = new Button
                {
                    Text = $"{player.Nome} {player.Cognome}",
                    Location = new Point(10, yOffset),
                    Width = 200
                };
                playerButton.Click += (sender, e) => PlayerButton_Click(player);
                playerNamesPanel.Controls.Add(playerButton);
                yOffset += 40; // Adjust spacing between buttons
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PlayerButton_Click(Giocatore player)
        {
            var mainForm = (ClashOfClansDatabaseApplication)this.ParentForm!;
            //mainForm.LoadPanel(new PlayerDetailsPanel(player));
        }

        private Button AddPlayerButton;
        private Button BackButton;
        private TextBox textBox1;
        private Label searchPlayerLabel;
        private Panel playerNamesPanel;
    }
}
