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
            ListViewGroup listViewGroup1 = new ListViewGroup("Edifici Speciali", HorizontalAlignment.Left);
            ListViewGroup listViewGroup2 = new ListViewGroup("Estrattori di Risorse", HorizontalAlignment.Left);
            ListViewGroup listViewGroup3 = new ListViewGroup("Difese", HorizontalAlignment.Left);
            leftSplitContainer = new SplitContainer();
            leftPanelsSplitContainer = new SplitContainer();
            accountUsernameLabel = new Label();
            playerNameLabel = new Label();
            backButton = new Button();
            buildersAndLaboratorySplitContainer = new SplitContainer();
            Costruttori = new ListBox();
            Laboratorio = new ListBox();
            rightSplitContainer = new SplitContainer();
            centralSplitContainer = new SplitContainer();
            flowLayoutPanel1 = new FlowLayoutPanel();
            forceLabel = new Label();
            trophiesLabel = new Label();
            starsLabel = new Label();
            xpLabel = new Label();
            tabControl1 = new TabControl();
            villageTab = new TabPage();
            attacksTab = new TabPage();
            clanTab = new TabPage();
            Truppe = new ListBox();
            listView1 = new ListView();
            ((System.ComponentModel.ISupportInitialize)leftSplitContainer).BeginInit();
            leftSplitContainer.Panel1.SuspendLayout();
            leftSplitContainer.Panel2.SuspendLayout();
            leftSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)leftPanelsSplitContainer).BeginInit();
            leftPanelsSplitContainer.Panel1.SuspendLayout();
            leftPanelsSplitContainer.Panel2.SuspendLayout();
            leftPanelsSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)buildersAndLaboratorySplitContainer).BeginInit();
            buildersAndLaboratorySplitContainer.Panel1.SuspendLayout();
            buildersAndLaboratorySplitContainer.Panel2.SuspendLayout();
            buildersAndLaboratorySplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rightSplitContainer).BeginInit();
            rightSplitContainer.Panel1.SuspendLayout();
            rightSplitContainer.Panel2.SuspendLayout();
            rightSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)centralSplitContainer).BeginInit();
            centralSplitContainer.Panel1.SuspendLayout();
            centralSplitContainer.Panel2.SuspendLayout();
            centralSplitContainer.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tabControl1.SuspendLayout();
            villageTab.SuspendLayout();
            SuspendLayout();
            // 
            // leftSplitContainer
            // 
            leftSplitContainer.Dock = DockStyle.Fill;
            leftSplitContainer.Location = new Point(0, 0);
            leftSplitContainer.Name = "leftSplitContainer";
            // 
            // leftSplitContainer.Panel1
            // 
            leftSplitContainer.Panel1.Controls.Add(leftPanelsSplitContainer);
            leftSplitContainer.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // leftSplitContainer.Panel2
            // 
            leftSplitContainer.Panel2.Controls.Add(rightSplitContainer);
            leftSplitContainer.Size = new Size(984, 561);
            leftSplitContainer.SplitterDistance = 211;
            leftSplitContainer.TabIndex = 0;
            // 
            // leftPanelsSplitContainer
            // 
            leftPanelsSplitContainer.Dock = DockStyle.Fill;
            leftPanelsSplitContainer.Location = new Point(0, 0);
            leftPanelsSplitContainer.Name = "leftPanelsSplitContainer";
            leftPanelsSplitContainer.Orientation = Orientation.Horizontal;
            // 
            // leftPanelsSplitContainer.Panel1
            // 
            leftPanelsSplitContainer.Panel1.Controls.Add(accountUsernameLabel);
            leftPanelsSplitContainer.Panel1.Controls.Add(playerNameLabel);
            leftPanelsSplitContainer.Panel1.Controls.Add(backButton);
            leftPanelsSplitContainer.Panel1.Paint += splitContainer2_Panel1_Paint;
            // 
            // leftPanelsSplitContainer.Panel2
            // 
            leftPanelsSplitContainer.Panel2.Controls.Add(buildersAndLaboratorySplitContainer);
            leftPanelsSplitContainer.Size = new Size(211, 561);
            leftPanelsSplitContainer.SplitterDistance = 109;
            leftPanelsSplitContainer.TabIndex = 0;
            // 
            // accountUsernameLabel
            // 
            accountUsernameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            accountUsernameLabel.Location = new Point(21, 80);
            accountUsernameLabel.Name = "accountUsernameLabel";
            accountUsernameLabel.Size = new Size(168, 15);
            accountUsernameLabel.TabIndex = 1;
            accountUsernameLabel.Text = "Username";
            accountUsernameLabel.Click += label1_Click;
            // 
            // playerNameLabel
            // 
            playerNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            playerNameLabel.Location = new Point(21, 61);
            playerNameLabel.Name = "playerNameLabel";
            playerNameLabel.Size = new Size(168, 15);
            playerNameLabel.TabIndex = 1;
            playerNameLabel.Text = "Nome Cognome";
            // 
            // backButton
            // 
            backButton.BackgroundImage = Properties.Resources.back_arrow;
            backButton.BackgroundImageLayout = ImageLayout.Zoom;
            backButton.Location = new Point(8, 8);
            backButton.Name = "backButton";
            backButton.Size = new Size(40, 40);
            backButton.TabIndex = 0;
            backButton.UseVisualStyleBackColor = true;
            // 
            // buildersAndLaboratorySplitContainer
            // 
            buildersAndLaboratorySplitContainer.Dock = DockStyle.Fill;
            buildersAndLaboratorySplitContainer.Location = new Point(0, 0);
            buildersAndLaboratorySplitContainer.Name = "buildersAndLaboratorySplitContainer";
            buildersAndLaboratorySplitContainer.Orientation = Orientation.Horizontal;
            // 
            // buildersAndLaboratorySplitContainer.Panel1
            // 
            buildersAndLaboratorySplitContainer.Panel1.Controls.Add(Costruttori);
            // 
            // buildersAndLaboratorySplitContainer.Panel2
            // 
            buildersAndLaboratorySplitContainer.Panel2.Controls.Add(Laboratorio);
            buildersAndLaboratorySplitContainer.Size = new Size(211, 448);
            buildersAndLaboratorySplitContainer.SplitterDistance = 293;
            buildersAndLaboratorySplitContainer.TabIndex = 0;
            // 
            // Costruttori
            // 
            Costruttori.Dock = DockStyle.Fill;
            Costruttori.FormattingEnabled = true;
            Costruttori.ItemHeight = 15;
            Costruttori.Location = new Point(0, 0);
            Costruttori.Name = "Costruttori";
            Costruttori.Size = new Size(211, 293);
            Costruttori.TabIndex = 0;
            // 
            // Laboratorio
            // 
            Laboratorio.Dock = DockStyle.Fill;
            Laboratorio.FormattingEnabled = true;
            Laboratorio.ItemHeight = 15;
            Laboratorio.Location = new Point(0, 0);
            Laboratorio.Name = "Laboratorio";
            Laboratorio.Size = new Size(211, 151);
            Laboratorio.TabIndex = 0;
            // 
            // rightSplitContainer
            // 
            rightSplitContainer.Dock = DockStyle.Fill;
            rightSplitContainer.Location = new Point(0, 0);
            rightSplitContainer.Name = "rightSplitContainer";
            // 
            // rightSplitContainer.Panel1
            // 
            rightSplitContainer.Panel1.Controls.Add(centralSplitContainer);
            // 
            // rightSplitContainer.Panel2
            // 
            rightSplitContainer.Panel2.Controls.Add(Truppe);
            rightSplitContainer.Size = new Size(769, 561);
            rightSplitContainer.SplitterDistance = 542;
            rightSplitContainer.TabIndex = 0;
            // 
            // centralSplitContainer
            // 
            centralSplitContainer.Dock = DockStyle.Fill;
            centralSplitContainer.Location = new Point(0, 0);
            centralSplitContainer.Name = "centralSplitContainer";
            centralSplitContainer.Orientation = Orientation.Horizontal;
            // 
            // centralSplitContainer.Panel1
            // 
            centralSplitContainer.Panel1.BackColor = Color.FromArgb(47, 108, 145);
            centralSplitContainer.Panel1.Controls.Add(flowLayoutPanel1);
            // 
            // centralSplitContainer.Panel2
            // 
            centralSplitContainer.Panel2.Controls.Add(tabControl1);
            centralSplitContainer.Size = new Size(542, 561);
            centralSplitContainer.SplitterDistance = 76;
            centralSplitContainer.TabIndex = 0;
            centralSplitContainer.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(forceLabel);
            flowLayoutPanel1.Controls.Add(trophiesLabel);
            flowLayoutPanel1.Controls.Add(starsLabel);
            flowLayoutPanel1.Controls.Add(xpLabel);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(542, 76);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // forceLabel
            // 
            forceLabel.AutoSize = true;
            forceLabel.BackColor = Color.FromArgb(0, 192, 192);
            forceLabel.Font = new Font("Segoe UI", 16F);
            forceLabel.ForeColor = Color.White;
            forceLabel.Location = new Point(3, 0);
            forceLabel.Name = "forceLabel";
            forceLabel.Size = new Size(119, 30);
            forceLabel.TabIndex = 0;
            forceLabel.Text = "Forza: 90%";
            // 
            // trophiesLabel
            // 
            trophiesLabel.AutoSize = true;
            trophiesLabel.BackColor = Color.FromArgb(0, 192, 192);
            trophiesLabel.Font = new Font("Segoe UI", 16F);
            trophiesLabel.ForeColor = Color.White;
            trophiesLabel.Location = new Point(128, 0);
            trophiesLabel.Name = "trophiesLabel";
            trophiesLabel.Size = new Size(127, 30);
            trophiesLabel.TabIndex = 0;
            trophiesLabel.Text = "Trofei: 1000";
            // 
            // starsLabel
            // 
            starsLabel.AutoSize = true;
            starsLabel.BackColor = Color.FromArgb(0, 192, 192);
            starsLabel.Font = new Font("Segoe UI", 16F);
            starsLabel.ForeColor = Color.White;
            starsLabel.Location = new Point(261, 0);
            starsLabel.Name = "starsLabel";
            starsLabel.Size = new Size(88, 30);
            starsLabel.TabIndex = 0;
            starsLabel.Text = "Stelle: 2";
            // 
            // xpLabel
            // 
            xpLabel.AutoSize = true;
            xpLabel.BackColor = Color.FromArgb(0, 192, 192);
            xpLabel.Font = new Font("Segoe UI", 16F);
            xpLabel.ForeColor = Color.White;
            xpLabel.Location = new Point(355, 0);
            xpLabel.Name = "xpLabel";
            xpLabel.Size = new Size(97, 30);
            xpLabel.TabIndex = 0;
            xpLabel.Text = "XP: 1000";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(villageTab);
            tabControl1.Controls.Add(attacksTab);
            tabControl1.Controls.Add(clanTab);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(542, 481);
            tabControl1.TabIndex = 0;
            // 
            // villageTab
            // 
            villageTab.Controls.Add(listView1);
            villageTab.Location = new Point(4, 24);
            villageTab.Name = "villageTab";
            villageTab.Padding = new Padding(3);
            villageTab.Size = new Size(534, 453);
            villageTab.TabIndex = 0;
            villageTab.Text = "Villaggio";
            villageTab.UseVisualStyleBackColor = true;
            // 
            // attacksTab
            // 
            attacksTab.Location = new Point(4, 24);
            attacksTab.Name = "attacksTab";
            attacksTab.Padding = new Padding(3);
            attacksTab.Size = new Size(534, 453);
            attacksTab.TabIndex = 1;
            attacksTab.Text = "Attacchi";
            attacksTab.UseVisualStyleBackColor = true;
            // 
            // clanTab
            // 
            clanTab.Location = new Point(4, 24);
            clanTab.Name = "clanTab";
            clanTab.Padding = new Padding(3);
            clanTab.Size = new Size(534, 453);
            clanTab.TabIndex = 2;
            clanTab.Text = "Clan";
            clanTab.UseVisualStyleBackColor = true;
            // 
            // Truppe
            // 
            Truppe.Dock = DockStyle.Fill;
            Truppe.FormattingEnabled = true;
            Truppe.ItemHeight = 15;
            Truppe.Location = new Point(0, 0);
            Truppe.Name = "Truppe";
            Truppe.Size = new Size(223, 561);
            Truppe.TabIndex = 0;
            // 
            // listView1
            // 
            listView1.Dock = DockStyle.Fill;
            listViewGroup1.Header = "Edifici Speciali";
            listViewGroup1.Name = "specialBuildingsListViewGroup";
            listViewGroup2.Header = "Estrattori di Risorse";
            listViewGroup2.Name = "resourcesExtractorsListViewGroup";
            listViewGroup3.Header = "Difese";
            listViewGroup3.Name = "defensesListViewGroup";
            listView1.Groups.AddRange(new ListViewGroup[] { listViewGroup1, listViewGroup2, listViewGroup3 });
            listView1.Location = new Point(3, 3);
            listView1.Name = "listView1";
            listView1.Size = new Size(528, 447);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // UseThisFormAsCanvas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(leftSplitContainer);
            MinimumSize = new Size(1000, 600);
            Name = "UseThisFormAsCanvas";
            Text = "Giocatore";
            Load += PlayersScreen_Load;
            leftSplitContainer.Panel1.ResumeLayout(false);
            leftSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)leftSplitContainer).EndInit();
            leftSplitContainer.ResumeLayout(false);
            leftPanelsSplitContainer.Panel1.ResumeLayout(false);
            leftPanelsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)leftPanelsSplitContainer).EndInit();
            leftPanelsSplitContainer.ResumeLayout(false);
            buildersAndLaboratorySplitContainer.Panel1.ResumeLayout(false);
            buildersAndLaboratorySplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)buildersAndLaboratorySplitContainer).EndInit();
            buildersAndLaboratorySplitContainer.ResumeLayout(false);
            rightSplitContainer.Panel1.ResumeLayout(false);
            rightSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)rightSplitContainer).EndInit();
            rightSplitContainer.ResumeLayout(false);
            centralSplitContainer.Panel1.ResumeLayout(false);
            centralSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)centralSplitContainer).EndInit();
            centralSplitContainer.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            villageTab.ResumeLayout(false);
            ResumeLayout(false);
        }

        private SplitContainer leftSplitContainer;
        private SplitContainer rightSplitContainer;
        private SplitContainer centralSplitContainer;
        private SplitContainer leftPanelsSplitContainer;
        private SplitContainer buildersAndLaboratorySplitContainer;
        private FlowLayoutPanel flowLayoutPanel1;
        private TabControl tabControl1;
        private TabPage villageTab;
        private TabPage attacksTab;
        private TabPage clanTab;
        private Label forceLabel;
        private Label trophiesLabel;
        private Label starsLabel;
        private Label xpLabel;
        private Button backButton;
        private Label playerNameLabel;
        private Label accountUsernameLabel;
        private ListBox Costruttori;
        private ListBox Laboratorio;
        private ListView listView1;
        private ListBox Truppe;
    }
}