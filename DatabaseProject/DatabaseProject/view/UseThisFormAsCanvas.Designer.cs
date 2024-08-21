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
            panel1 = new Panel();
            panel3 = new Panel();
            tabControl1 = new TabControl();
            Villaggio = new TabPage();
            Attacchi = new TabPage();
            Clan = new TabPage();
            panel4 = new Panel();
            panel2 = new Panel();
            leftPanel = new Panel();
            panel3.SuspendLayout();
            tabControl1.SuspendLayout();
            leftPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(1013, 0);
            panel1.MinimumSize = new Size(200, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 678);
            panel1.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(tabControl1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(200, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(813, 678);
            panel3.TabIndex = 3;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(Villaggio);
            tabControl1.Controls.Add(Attacchi);
            tabControl1.Controls.Add(Clan);
            tabControl1.Location = new Point(6, 106);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(801, 572);
            tabControl1.TabIndex = 1;
            // 
            // Villaggio
            // 
            Villaggio.AutoScroll = true;
            Villaggio.Location = new Point(4, 24);
            Villaggio.Name = "Villaggio";
            Villaggio.Padding = new Padding(3);
            Villaggio.Size = new Size(793, 544);
            Villaggio.TabIndex = 0;
            Villaggio.Text = "Villaggio";
            Villaggio.UseVisualStyleBackColor = true;
            // 
            // Attacchi
            // 
            Attacchi.Location = new Point(4, 24);
            Attacchi.Name = "Attacchi";
            Attacchi.Padding = new Padding(3);
            Attacchi.Size = new Size(531, 406);
            Attacchi.TabIndex = 1;
            Attacchi.Text = "Attacchi";
            Attacchi.UseVisualStyleBackColor = true;
            // 
            // Clan
            // 
            Clan.Location = new Point(4, 24);
            Clan.Name = "Clan";
            Clan.Size = new Size(531, 406);
            Clan.TabIndex = 2;
            Clan.Text = "Clan";
            Clan.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel4.BackColor = SystemColors.ControlDarkDark;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(813, 100);
            panel4.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Location = new Point(206, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(593, 89);
            panel2.TabIndex = 3;
            // 
            // leftPanel
            // 
            leftPanel.AutoScroll = true;
            leftPanel.Controls.Add(panel2);
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Location = new Point(0, 0);
            leftPanel.MinimumSize = new Size(200, 0);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(200, 678);
            leftPanel.TabIndex = 1;
            // 
            // UseThisFormAsCanvas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1213, 678);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(leftPanel);
            MinimumSize = new Size(1000, 600);
            Name = "UseThisFormAsCanvas";
            Text = "Giocatore";
            Load += PlayersScreen_Load;
            panel3.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            leftPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel panel1;
        private Panel panel4;
        private Panel panel3;
        private TabControl tabControl1;
        private TabPage Villaggio;
        private TabPage Attacchi;
        private TabPage Clan;
        private Panel panel2;
        private Panel leftPanel;
    }
}