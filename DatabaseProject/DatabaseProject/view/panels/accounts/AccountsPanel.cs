using DatabaseProject.daos;
using DatabaseProject.database;

namespace DatabaseProject.view.panels.account
{
    class AccountsPanel : UserControl
    {
        private readonly Giocatore player;
        private SearchBar<Account> searchBar;
        private Button addAccountButton;
        private Button backButton;
        private TextBox textBox1;
        private Label label1;
        private Panel accountUsernamesPanel;
        private Label playerNameLabel;

        public AccountsPanel(Giocatore player)
        {
            this.player = player;
            InitializeComponent();
            LoadAccountsButtons(accountUsernamesPanel!);
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountsPanel));
            addAccountButton = new Button();
            backButton = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            playerNameLabel = new Label();
            accountUsernamesPanel = new Panel();
            SuspendLayout();
            // 
            // addAccountButton
            // 
            addAccountButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            addAccountButton.Location = new Point(136, 83);
            addAccountButton.Name = "addAccountButton";
            addAccountButton.Size = new Size(330, 93);
            addAccountButton.TabIndex = 0;
            addAccountButton.Text = "Aggiungi Account";
            addAccountButton.UseVisualStyleBackColor = true;
            addAccountButton.Click += AddAccountButton_Click;
            // 
            // backButton
            // 
            backButton.BackgroundImage = (Image)resources.GetObject("backButton.BackgroundImage");
            backButton.BackgroundImageLayout = ImageLayout.Center;
            backButton.Location = new Point(12, 12);
            backButton.Name = "backButton";
            backButton.Size = new Size(50, 50);
            backButton.TabIndex = 1;
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += BackButton_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Cursor = Cursors.IBeam;
            textBox1.Font = new Font("Segoe UI", 16F);
            textBox1.Location = new Point(136, 222);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Inserisci lo username dell'account...";
            textBox1.Size = new Size(330, 36);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += TextBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(135, 192);
            label1.Name = "label1";
            label1.Size = new Size(107, 21);
            label1.TabIndex = 3;
            label1.Text = "Cerca account";
            // 
            // playerNameLabel
            // 
            playerNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            playerNameLabel.AutoEllipsis = true;
            playerNameLabel.Font = new Font("Segoe UI", 25F);
            playerNameLabel.Location = new Point(136, 25);
            playerNameLabel.Name = "playerNameLabel";
            playerNameLabel.Size = new Size(330, 46);
            playerNameLabel.TabIndex = 5;
            playerNameLabel.Text = $"Giocatore: {player.Nome} {player.Cognome}";
            playerNameLabel.TextAlign = ContentAlignment.TopCenter;

            AdjustFontSizeToFit(playerNameLabel);

            // 
            // accountUsernamesPanel
            // 
            accountUsernamesPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            accountUsernamesPanel.AutoScroll = true;
            accountUsernamesPanel.BackColor = Color.White;
            accountUsernamesPanel.BorderStyle = BorderStyle.FixedSingle;
            accountUsernamesPanel.Location = new Point(136, 264);
            accountUsernamesPanel.Name = "accountUsernamesPanel";
            accountUsernamesPanel.Size = new Size(330, 202);
            accountUsernamesPanel.TabIndex = 6;
            // 
            // AccountsPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(accountUsernamesPanel);
            Controls.Add(backButton);
            Controls.Add(playerNameLabel);
            Controls.Add(addAccountButton);
            Controls.Add(label1);
            Controls.Add(textBox1);
            MinimumSize = new Size(600, 500);
            Name = "AccountsPanel";
            Size = new Size(600, 500);
            Load += AccountsPanel_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void AddAccountButton_Click(object sender, EventArgs e)
        {
            using var accountInsertionForm = new AccountInsertionForm(player);
            accountInsertionForm.ShowDialog();
            if (accountInsertionForm.DialogResult == DialogResult.OK)
            {
                LoadAccountsButtons(accountUsernamesPanel);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var mainForm = (ClashOfClansDatabaseApplication)ParentForm!;
            mainForm.LoadPanel(new PlayersPanel());
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            searchBar.FilterEntries(entry => entry.Username.ToLower().Contains(textBox1.Text.ToLower()));
            var filteredEntries = searchBar.GetFilteredEntries();
            accountUsernamesPanel.Controls.Clear();

            foreach (var entry in filteredEntries)
            {
                Button playerButton = new()
                {
                    Text = $"{entry.Username}",
                    Dock = DockStyle.Top,
                    Height = 40,
                };
                playerButton.Click += (sender, e) => AccountButton_Click(entry);
                accountUsernamesPanel.Controls.Add(playerButton);
            }
        }

        private void LoadAccountsButtons(Panel accountsPanel)
        {
            List<Account> accounts = AccountDao.GetAccountsFromPlayer(player);
            searchBar = new SearchBar<Account>(accounts);
            accountsPanel.Controls.Clear();

            foreach (var account in accounts)
            {
                Button accountButton = new()
                {
                    Text = $"{account.Username}",
                    Dock = DockStyle.Top,
                    Height = 40,
                };
                accountButton.Click += (sender, e) => AccountButton_Click(account);
                accountsPanel.Controls.Add(accountButton);
            }
        }

        private void AccountButton_Click(Account account)
        {
            // Go to village page

        }

        private void AdjustFontSizeToFit(Label label)
        {
            // Start with the current font size
            float fontSize = label.Font.Size;
            SizeF textSize;

            // Measure the text size
            using (Graphics g = label.CreateGraphics())
            {
                textSize = g.MeasureString(label.Text, new Font(label.Font.FontFamily, fontSize));
            }

            // Reduce the font size until the text fits within the label's bounds
            while (textSize.Width > label.Width && fontSize > 1)
            {
                fontSize -= 0.5f;
                using (Graphics g = label.CreateGraphics())
                {
                    textSize = g.MeasureString(label.Text, new Font(label.Font.FontFamily, fontSize));
                }
            }

            // Set the adjusted font size
            label.Font = new Font(label.Font.FontFamily, fontSize);
        }

        private void AccountsPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
