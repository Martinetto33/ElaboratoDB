namespace DatabaseProject
{
    partial class PlayersScreen
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayersScreen));
            AddPlayerTestButton = new Button();
            BackButton = new Button();
            panelContainer = new Panel();
            SuspendLayout();
            // 
            // AddPlayerTestButton
            // 
            AddPlayerTestButton.Location = new Point(122, 101);
            AddPlayerTestButton.Name = "AddPlayerTestButton";
            AddPlayerTestButton.Size = new Size(530, 93);
            AddPlayerTestButton.TabIndex = 0;
            AddPlayerTestButton.Text = "Aggiungi Giocatore [Test]";
            AddPlayerTestButton.UseVisualStyleBackColor = true;
            AddPlayerTestButton.Click += AddPlayerTestButton_Click;
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
            // panelContainer
            // 
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(800, 450);
            panelContainer.TabIndex = 2;
            // 
            // PlayersScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelContainer);
            Controls.Add(BackButton);
            Controls.Add(AddPlayerTestButton);
            Name = "PlayersScreen";
            Text = "Giocatori";
            Load += PlayersScreen_Load;
            ResumeLayout(false);

            // Adding buttons to the panel container
            panelContainer.Controls.Add(AddPlayerTestButton);
            panelContainer.Controls.Add(BackButton);
        }

        #endregion

        private Button AddPlayerTestButton;
        private Button BackButton;
        private Panel panelContainer;
    }
}