namespace DatabaseProject.view.panels
{
    /**
     * This class represents the initial menu panel.
     * I think the error I was making was trying to create a new form for each "screen" I wanted to display;
     * I should make a panel for each screen and load it into the main form instead.
     */
    public class InitialMenuPanel : UserControl
    {
        public InitialMenuPanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            var ExitButton = new Button();
            var PlayersButton = new Button();
            var ClansButton = new Button();
            var WarsButton = new Button();
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
            // InitialMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 461);
            MinimumSize = new Size(600, 500);
            Name = "InitialMenu";
            Text = "Clash of Clans Database";

            this.Controls.Add(ExitButton);
            this.Controls.Add(PlayersButton);
            this.Controls.Add(ClansButton);
            this.Controls.Add(WarsButton);
            ResumeLayout(false);
        }

        // The Exit button
        private void exitButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void playersButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Players button clicked");
            // This is the method to change panel in the parent
            var mainForm = (ClashOfClansDatabaseApplication)this.Parent!;
            mainForm.LoadPanel(new PlayersPanel());
        }

        private void clansButton_Click(object sender, EventArgs e)
        {
            /*ClansMenu clansMenu = new ClansMenu();
            clansMenu.Show();*/
            Console.WriteLine("Clans button clicked");
        }

        private void warsButton_Click(object sender, EventArgs e)
        {
            /*WarsMenu warsMenu = new WarsMenu();
            warsMenu.Show();*/
            Console.WriteLine("Wars button clicked");
        }
    }
}
