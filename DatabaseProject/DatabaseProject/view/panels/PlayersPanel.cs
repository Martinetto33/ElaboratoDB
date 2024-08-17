using DatabaseProject.daos;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UseThisFormAsCanvas));
            var AddPlayerButton = new Button();
            var BackButton = new Button();
            SuspendLayout();
            // 
            // AddPlayerTestButton
            // 
            AddPlayerButton.Location = new Point(122, 101);
            AddPlayerButton.Name = "AddPlayerTestButton";
            AddPlayerButton.Size = new Size(530, 93);
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

            this.Controls.Add(AddPlayerButton);
            this.Controls.Add(BackButton);

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
