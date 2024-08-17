namespace DatabaseProject
{
    partial class UseThisFormAsCanvas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UseThisFormAsCanvas));
            AddPlayerTestButton = new Button();
            BackButton = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            PlayersPanel = new Panel();
            SuspendLayout();
            // 
            // AddPlayerTestButton
            // 
            AddPlayerTestButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AddPlayerTestButton.Location = new Point(136, 26);
            AddPlayerTestButton.Name = "AddPlayerTestButton";
            AddPlayerTestButton.Size = new Size(524, 93);
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
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Cursor = Cursors.IBeam;
            textBox1.Font = new Font("Segoe UI", 16F);
            textBox1.Location = new Point(136, 165);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Inserisci il nome del giocatore...";
            textBox1.Size = new Size(524, 36);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(135, 135);
            label1.Name = "label1";
            label1.Size = new Size(118, 21);
            label1.TabIndex = 3;
            label1.Text = "Cerca giocatore";
            label1.Click += label1_Click;
            // 
            // PlayersPanel
            // 
            PlayersPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PlayersPanel.AutoScroll = true;
            PlayersPanel.BackColor = Color.White;
            PlayersPanel.BorderStyle = BorderStyle.FixedSingle;
            PlayersPanel.Location = new Point(136, 214);
            PlayersPanel.Name = "PlayersPanel";
            PlayersPanel.Padding = new Padding(10);
            PlayersPanel.Size = new Size(524, 246);
            PlayersPanel.TabIndex = 4;
            // 
            // UseThisFormAsCanvas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 472);
            Controls.Add(PlayersPanel);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(BackButton);
            Controls.Add(AddPlayerTestButton);
            MinimumSize = new Size(600, 500);
            Name = "UseThisFormAsCanvas";
            Text = "Giocatori";
            Load += PlayersScreen_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddPlayerTestButton;
        private Button BackButton;
        private TextBox textBox1;
        private Label label1;
        private Panel PlayersPanel;
    }
}