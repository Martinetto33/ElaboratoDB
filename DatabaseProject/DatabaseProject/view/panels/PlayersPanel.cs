using DatabaseProject.daos;

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
            var AddPlayerButton = new Button();
            var BackButton = new Button();
            SuspendLayout();
            // 
            // AddPlayerButton
            // 
            AddPlayerButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AddPlayerButton.Font = new Font("Segoe UI", 15F);
            AddPlayerButton.Location = new Point(156, 41);
            AddPlayerButton.Name = "AddPlayerButton";
            AddPlayerButton.Size = new Size(409, 77);
            AddPlayerButton.TabIndex = 1;
            AddPlayerButton.Text = "Aggiungi Giocatore";
            AddPlayerButton.UseVisualStyleBackColor = true;
            AddPlayerButton.Click += AddPlayerButton_Click;
            // 
            // BackButton
            // 
            BackButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BackButton.Font = new Font("Segoe UI", 15F);
            BackButton.Location = new Point(156, 138);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(409, 77);
            BackButton.TabIndex = 2;
            BackButton.Text = "Indietro";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;

            this.Controls.Add(AddPlayerButton);
            this.Controls.Add(BackButton);

            // TODO: add image to back button and resize correctly the panels
            ResumeLayout(false);
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
    }
}
