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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UseThisFormAsCanvas));
            addAccountButton = new Button();
            backButton = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            accountsPanel = new Panel();
            playerNameLabel = new Label();
            SuspendLayout();
            // 
            // addAccountButton
            // 
            addAccountButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            addAccountButton.Location = new Point(136, 87);
            addAccountButton.Name = "addAccountButton";
            addAccountButton.Size = new Size(524, 93);
            addAccountButton.TabIndex = 0;
            addAccountButton.Text = "Aggiungi Account";
            addAccountButton.UseVisualStyleBackColor = true;
            addAccountButton.Click += AddPlayerTestButton_Click;
            // 
            // backButton
            // 
            backButton.Image = (Image)resources.GetObject("backButton.Image");
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
            textBox1.Location = new Point(136, 226);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Inserisci lo username dell'account...";
            textBox1.Size = new Size(524, 36);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(135, 196);
            label1.Name = "label1";
            label1.Size = new Size(107, 21);
            label1.TabIndex = 3;
            label1.Text = "Cerca account";
            label1.Click += label1_Click;
            // 
            // accountsPanel
            // 
            accountsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            accountsPanel.AutoScroll = true;
            accountsPanel.BackColor = Color.White;
            accountsPanel.BorderStyle = BorderStyle.FixedSingle;
            accountsPanel.Location = new Point(136, 268);
            accountsPanel.Name = "accountsPanel";
            accountsPanel.Padding = new Padding(10);
            accountsPanel.Size = new Size(524, 255);
            accountsPanel.TabIndex = 4;
            // 
            // playerNameLabel
            // 
            playerNameLabel.AutoSize = true;
            playerNameLabel.Font = new Font("Segoe UI", 25F);
            playerNameLabel.Location = new Point(264, 16);
            playerNameLabel.Name = "playerNameLabel";
            playerNameLabel.Size = new Size(267, 46);
            playerNameLabel.TabIndex = 5;
            playerNameLabel.Text = "Nome Giocatore";
            playerNameLabel.Click += label2_Click;
            // 
            // UseThisFormAsCanvas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 535);
            Controls.Add(playerNameLabel);
            Controls.Add(accountsPanel);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(backButton);
            Controls.Add(addAccountButton);
            MinimumSize = new Size(600, 500);
            Name = "UseThisFormAsCanvas";
            Text = "Giocatore";
            Load += PlayersScreen_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Button addAccountButton;
        private Button backButton;
        private TextBox textBox1;
        private Label label1;
        private Panel accountsPanel;
        private Label playerNameLabel;
    }
}