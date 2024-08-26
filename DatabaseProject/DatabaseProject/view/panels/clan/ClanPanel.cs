using DatabaseProject.daos;
using DatabaseProject.mapper;
using DatabaseProject.model.code;
using DatabaseProject.view.panels.account;
using DatabaseProject.view.panels.initialmenu;

namespace DatabaseProject.view.panels.player
{
    public class ClanPanel : UserControl
    {
        private SearchBar<Clan> searchBar;
        public ClanPanel()
        {
            InitializeComponent();
            LoadClanButtons(clanNamesPanel!);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClanPanel));
            AddClanButton = new Button();
            BackButton = new Button();
            textBox1 = new TextBox();
            searchClanLabel = new Label();
            clanNamesPanel = new Panel();
            SuspendLayout();
            // 
            // AddClanButton
            // 
            AddClanButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AddClanButton.Location = new Point(108, 26);
            AddClanButton.Name = "AddClanButton";
            AddClanButton.Size = new Size(645, 93);
            AddClanButton.TabIndex = 0;
            AddClanButton.Text = "Aggiungi Clan";
            AddClanButton.UseVisualStyleBackColor = true;
            AddClanButton.Click += AddClanButton_Click;
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
            textBox1.PlaceholderText = "Inserisci il nome del clan...";
            textBox1.Size = new Size(645, 36);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // searchClanLabel
            // 
            searchClanLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            searchClanLabel.AutoSize = true;
            searchClanLabel.Font = new Font("Segoe UI", 12F);
            searchClanLabel.Location = new Point(107, 135);
            searchClanLabel.Name = "searchClanLabel";
            searchClanLabel.Size = new Size(81, 21);
            searchClanLabel.TabIndex = 3;
            searchClanLabel.Text = "Cerca clan";
            // 
            // clanNamesPanel
            // 
            clanNamesPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            clanNamesPanel.AutoScroll = true;
            clanNamesPanel.BackColor = Color.White;
            clanNamesPanel.BorderStyle = BorderStyle.FixedSingle;
            clanNamesPanel.Location = new Point(108, 231);
            clanNamesPanel.Name = "clanNamesPanel";
            clanNamesPanel.Padding = new Padding(10);
            clanNamesPanel.Size = new Size(645, 323);
            clanNamesPanel.TabIndex = 4;
            // 
            // ClanPanel
            // 
            Controls.Add(AddClanButton);
            Controls.Add(BackButton);
            Controls.Add(textBox1);
            Controls.Add(searchClanLabel);
            Controls.Add(clanNamesPanel);
            Name = "ClanPanel";
            Size = new Size(860, 560);
            ResumeLayout(false);
            PerformLayout();
        }

        private void AddClanButton_Click(object sender, EventArgs e)
        {
            ShowClanInsertionForm();
        }

        private void ShowClanInsertionForm()
        {
            using var clanInsertionForm = new ClanInsertionForm();
            clanInsertionForm.ShowDialog();
            if (clanInsertionForm.DialogResult == DialogResult.OK)
            {
                Console.WriteLine("Clan added");
                LoadClanButtons(clanNamesPanel);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var mainForm = (ClashOfClansDatabaseApplication)ParentForm!;
            mainForm.LoadPanel(new InitialMenuPanel());
        }

        private void LoadClanButtons(Panel clanNamesPanel)
        {
            List<Clan> clanList = ClanDao.GetAllClans()
                .Select(dbClan => DatabaseToModelMapper.Map(dbClan))
                .ToList();
            searchBar = new SearchBar<Clan>(clanList);
            clanNamesPanel.Controls.Clear();

            foreach (var clan in clanList)
            {
                Button clanButton = new()
                {
                    Text = clan.Name,
                    Dock = DockStyle.Top,
                    Height = 40,
                };
                clanButton.Click += (sender, e) => ClanButton_Click(clan);
                clanNamesPanel.Controls.Add(clanButton);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchBar.FilterEntries(e => e.Name.ToLower().Contains(textBox1.Text.ToLower()));
            var filteredEntries = searchBar.GetFilteredEntries();
            clanNamesPanel.Controls.Clear();

            foreach (var entry in filteredEntries)
            {
                Button clanButton = new()
                {
                    Text = entry.Name,
                    Dock = DockStyle.Top,
                    Height = 40,
                };
                clanButton.Click += (sender, e) => ClanButton_Click(entry);
                clanNamesPanel.Controls.Add(clanButton);
            }
        }

        private void ClanButton_Click(Clan clan)
        {
            var mainForm = (ClashOfClansDatabaseApplication)ParentForm!;
            //mainForm.LoadPanel(new ClanDetailsPanel(clan));
        }

        private Button AddClanButton;
        private Button BackButton;
        private TextBox textBox1;
        private Label searchClanLabel;
        private Panel clanNamesPanel;
    }
}
