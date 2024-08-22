using DatabaseProject.daos;
using DatabaseProject.database;

namespace DatabaseProject.view.panels.player
{
    internal class PlayersPanel : UserControl
    {
        private SearchBar<Giocatore> searchBar;
        public PlayersPanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
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
            AddPlayerButton.Text = "Aggiungi Giocatore";
            AddPlayerButton.UseVisualStyleBackColor = true;
            AddPlayerButton.Click += AddPlayerButton_Click;
            // 
            // backButton
            // 
            BackButton.Image = images.ImageLoader.BackArrow();
            BackButton.Location = new Point(12, 12);
            BackButton.Name = "backButton";
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

            // fetching data from database
            LoadPlayerButtons(playerNamesPanel);

            // 
            // accountsPanel
            // 
            Controls.Add(AddPlayerButton);
            Controls.Add(BackButton);
            Controls.Add(textBox1);
            Controls.Add(searchPlayerLabel);
            Controls.Add(playerNamesPanel);
            Name = "accountsPanel";
            Size = new Size(860, 560);
            ResumeLayout(false);
            PerformLayout();
        }

        private void AddPlayerButton_Click(object sender, EventArgs e)
        {
            //PlayerDao.CreatePlayer("Alin", "Bordeianu");
            //Console.WriteLine("Player added");
            ShowPlayerInsertionForm();
        }

        private void ShowPlayerInsertionForm()
        {
            using var playerInsertionForm = new PlayerInsertionForm();
            playerInsertionForm.ShowDialog();
            if (playerInsertionForm.DialogResult == DialogResult.OK)
            {
                LoadPlayerButtons(playerNamesPanel);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var mainForm = (ClashOfClansDatabaseApplication)ParentForm!;
            mainForm.LoadPanel(new InitialMenuPanel());
        }

        private void LoadPlayerButtons(Panel playerNamesPanel)
        {
            List<Giocatore> players = [.. PlayerDao.GetAllPlayers().OrderBy(player => player.Cognome)];
            searchBar = new SearchBar<Giocatore>(players);
            playerNamesPanel.Controls.Clear();

            foreach (var player in players)
            {
                Button playerButton = new()
                {
                    Text = $"{player.Nome} {player.Cognome}",
                    Dock = DockStyle.Top,
                    Height = 40,
                };
                playerButton.Click += (sender, e) => PlayerButton_Click(player);
                playerNamesPanel.Controls.Add(playerButton);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchBar.FilterEntries(e => $"{e.Nome} {e.Cognome}".ToLower().Contains(textBox1.Text.ToLower()));
            var filteredEntries = searchBar.GetFilteredEntries();
            playerNamesPanel.Controls.Clear();

            foreach (var entry in filteredEntries)
            {
                Button playerButton = new()
                {
                    Text = $"{entry.Nome} {entry.Cognome}",
                    Dock = DockStyle.Top,
                    Height = 40,
                };
                playerButton.Click += (sender, e) => PlayerButton_Click(entry);
                playerNamesPanel.Controls.Add(playerButton);
            }
        }

        private void PlayerButton_Click(Giocatore player)
        {
            var mainForm = (ClashOfClansDatabaseApplication)ParentForm!;
            mainForm.LoadPanel(new AccountsPanel(player));
        }

        private Button AddPlayerButton;
        private Button BackButton;
        private TextBox textBox1;
        private Label searchPlayerLabel;
        private Panel playerNamesPanel;
    }
}
