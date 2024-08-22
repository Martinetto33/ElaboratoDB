namespace DatabaseProject.view.panels.village
{
    public partial class VillagePanel
    {
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
        private ListView listView1;
        private ListView listView2;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private SplitContainer clanTabSplitContainer;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label clanNameLabel;
        private Label clanRoleLabel;
        private Label membersNumberLabel;
        private Label trophiesNumberLabel;
        private Label starsNumberLabel;
        private ListView listView3;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private GroupBox Costruttori;
        private GroupBox Laboratorio;
        private ListView troopsListView;

        private void InitializeComponent()
        {
            ListViewGroup listViewGroup4 = new ListViewGroup("Edifici Speciali", HorizontalAlignment.Left);
            ListViewGroup listViewGroup5 = new ListViewGroup("Estrattori di Risorse", HorizontalAlignment.Left);
            ListViewGroup listViewGroup6 = new ListViewGroup("Difese", HorizontalAlignment.Left);
            leftSplitContainer = new SplitContainer();
            leftPanelsSplitContainer = new SplitContainer();
            accountUsernameLabel = new Label();
            playerNameLabel = new Label();
            backButton = new Button();
            buildersAndLaboratorySplitContainer = new SplitContainer();
            Costruttori = new GroupBox();
            rightSplitContainer = new SplitContainer();
            centralSplitContainer = new SplitContainer();
            flowLayoutPanel1 = new FlowLayoutPanel();
            forceLabel = new Label();
            trophiesLabel = new Label();
            starsLabel = new Label();
            xpLabel = new Label();
            tabControl1 = new TabControl();
            villageTab = new TabPage();
            listView1 = new ListView();
            attacksTab = new TabPage();
            listView2 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            clanTab = new TabPage();
            clanTabSplitContainer = new SplitContainer();
            flowLayoutPanel2 = new FlowLayoutPanel();
            clanNameLabel = new Label();
            clanRoleLabel = new Label();
            membersNumberLabel = new Label();
            trophiesNumberLabel = new Label();
            starsNumberLabel = new Label();
            listView3 = new ListView();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            troopsListView = new ListView();
            Laboratorio = new GroupBox();
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
            attacksTab.SuspendLayout();
            clanTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)clanTabSplitContainer).BeginInit();
            clanTabSplitContainer.Panel1.SuspendLayout();
            clanTabSplitContainer.Panel2.SuspendLayout();
            clanTabSplitContainer.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
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
            // 
            // leftSplitContainer.Panel2
            // 
            leftSplitContainer.Panel2.Controls.Add(rightSplitContainer);
            leftSplitContainer.Size = new Size(1000, 600);
            leftSplitContainer.SplitterDistance = 214;
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
            // 
            // leftPanelsSplitContainer.Panel2
            // 
            leftPanelsSplitContainer.Panel2.Controls.Add(buildersAndLaboratorySplitContainer);
            leftPanelsSplitContainer.Size = new Size(214, 600);
            leftPanelsSplitContainer.SplitterDistance = 116;
            leftPanelsSplitContainer.TabIndex = 0;
            // 
            // accountUsernameLabel
            // 
            accountUsernameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            accountUsernameLabel.Location = new Point(21, 80);
            accountUsernameLabel.Name = "accountUsernameLabel";
            accountUsernameLabel.Size = new Size(171, 15);
            accountUsernameLabel.TabIndex = 1;
            accountUsernameLabel.Text = "Username";
            // 
            // playerNameLabel
            // 
            playerNameLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            playerNameLabel.Location = new Point(21, 61);
            playerNameLabel.Name = "playerNameLabel";
            playerNameLabel.Size = new Size(171, 15);
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
            buildersAndLaboratorySplitContainer.Size = new Size(214, 480);
            buildersAndLaboratorySplitContainer.SplitterDistance = 313;
            buildersAndLaboratorySplitContainer.TabIndex = 0;
            // 
            // Costruttori
            // 
            Costruttori.Dock = DockStyle.Fill;
            Costruttori.Location = new Point(0, 0);
            Costruttori.Name = "Costruttori";
            Costruttori.Size = new Size(214, 313);
            Costruttori.TabIndex = 0;
            Costruttori.TabStop = false;
            Costruttori.Text = "Costruttori";
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
            rightSplitContainer.Panel2.Controls.Add(troopsListView);
            rightSplitContainer.Size = new Size(782, 600);
            rightSplitContainer.SplitterDistance = 551;
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
            centralSplitContainer.Size = new Size(551, 600);
            centralSplitContainer.SplitterDistance = 81;
            centralSplitContainer.TabIndex = 0;
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
            flowLayoutPanel1.Size = new Size(551, 81);
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
            tabControl1.Size = new Size(551, 515);
            tabControl1.TabIndex = 0;
            // 
            // villageTab
            // 
            villageTab.Controls.Add(listView1);
            villageTab.Location = new Point(4, 24);
            villageTab.Name = "villageTab";
            villageTab.Padding = new Padding(3);
            villageTab.Size = new Size(543, 487);
            villageTab.TabIndex = 0;
            villageTab.Text = "Villaggio";
            villageTab.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.Dock = DockStyle.Fill;
            listViewGroup4.Header = "Edifici Speciali";
            listViewGroup4.Name = "specialBuildingsListViewGroup";
            listViewGroup5.Header = "Estrattori di Risorse";
            listViewGroup5.Name = "resourcesExtractorsListViewGroup";
            listViewGroup6.Header = "Difese";
            listViewGroup6.Name = "defensesListViewGroup";
            listView1.Groups.AddRange(new ListViewGroup[] { listViewGroup4, listViewGroup5, listViewGroup6 });
            listView1.Location = new Point(3, 3);
            listView1.Name = "listView1";
            listView1.Size = new Size(537, 481);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // attacksTab
            // 
            attacksTab.Controls.Add(listView2);
            attacksTab.Location = new Point(4, 24);
            attacksTab.Name = "attacksTab";
            attacksTab.Padding = new Padding(3);
            attacksTab.Size = new Size(543, 487);
            attacksTab.TabIndex = 1;
            attacksTab.Text = "Attacchi e difese";
            attacksTab.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader8 });
            listView2.Dock = DockStyle.Fill;
            listView2.GridLines = true;
            listView2.Location = new Point(3, 3);
            listView2.Name = "listView2";
            listView2.Size = new Size(537, 481);
            listView2.TabIndex = 0;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Stelle";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Percentuale";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Tempo";
            columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Trofei";
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Tipo (Attacco o Difesa)";
            columnHeader8.Width = 200;
            // 
            // clanTab
            // 
            clanTab.Controls.Add(clanTabSplitContainer);
            clanTab.Location = new Point(4, 24);
            clanTab.Name = "clanTab";
            clanTab.Padding = new Padding(3);
            clanTab.Size = new Size(543, 487);
            clanTab.TabIndex = 2;
            clanTab.Text = "Clan";
            clanTab.UseVisualStyleBackColor = true;
            // 
            // clanTabSplitContainer
            // 
            clanTabSplitContainer.Dock = DockStyle.Fill;
            clanTabSplitContainer.Location = new Point(3, 3);
            clanTabSplitContainer.Name = "clanTabSplitContainer";
            clanTabSplitContainer.Orientation = Orientation.Horizontal;
            // 
            // clanTabSplitContainer.Panel1
            // 
            clanTabSplitContainer.Panel1.Controls.Add(flowLayoutPanel2);
            // 
            // clanTabSplitContainer.Panel2
            // 
            clanTabSplitContainer.Panel2.Controls.Add(listView3);
            clanTabSplitContainer.Size = new Size(537, 481);
            clanTabSplitContainer.SplitterDistance = 102;
            clanTabSplitContainer.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.FromArgb(61, 174, 190);
            flowLayoutPanel2.Controls.Add(clanNameLabel);
            flowLayoutPanel2.Controls.Add(clanRoleLabel);
            flowLayoutPanel2.Controls.Add(membersNumberLabel);
            flowLayoutPanel2.Controls.Add(trophiesNumberLabel);
            flowLayoutPanel2.Controls.Add(starsNumberLabel);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(0, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(537, 102);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // clanNameLabel
            // 
            clanNameLabel.AutoSize = true;
            clanNameLabel.Font = new Font("Segoe UI", 20F);
            clanNameLabel.Location = new Point(3, 0);
            clanNameLabel.Name = "clanNameLabel";
            clanNameLabel.Size = new Size(197, 37);
            clanNameLabel.TabIndex = 1;
            clanNameLabel.Text = "Clan: Babbucce";
            // 
            // clanRoleLabel
            // 
            clanRoleLabel.AutoSize = true;
            clanRoleLabel.BackColor = Color.FromArgb(255, 128, 0);
            clanRoleLabel.Location = new Point(206, 0);
            clanRoleLabel.Name = "clanRoleLabel";
            clanRoleLabel.Size = new Size(87, 15);
            clanRoleLabel.TabIndex = 0;
            clanRoleLabel.Text = "Ruolo: Anziano";
            // 
            // membersNumberLabel
            // 
            membersNumberLabel.AutoSize = true;
            membersNumberLabel.Location = new Point(299, 0);
            membersNumberLabel.Name = "membersNumberLabel";
            membersNumberLabel.Size = new Size(84, 15);
            membersNumberLabel.TabIndex = 2;
            membersNumberLabel.Text = "Membri: 39/50";
            // 
            // trophiesNumberLabel
            // 
            trophiesNumberLabel.AutoSize = true;
            trophiesNumberLabel.Location = new Point(389, 0);
            trophiesNumberLabel.Name = "trophiesNumberLabel";
            trophiesNumberLabel.Size = new Size(66, 15);
            trophiesNumberLabel.TabIndex = 3;
            trophiesNumberLabel.Text = "Trofei: 5000";
            // 
            // starsNumberLabel
            // 
            starsNumberLabel.AutoSize = true;
            starsNumberLabel.Location = new Point(461, 0);
            starsNumberLabel.Name = "starsNumberLabel";
            starsNumberLabel.Size = new Size(53, 15);
            starsNumberLabel.TabIndex = 4;
            starsNumberLabel.Text = "Stelle: 15";
            // 
            // listView3
            // 
            listView3.Columns.AddRange(new ColumnHeader[] { columnHeader5, columnHeader6, columnHeader7 });
            listView3.Dock = DockStyle.Fill;
            listView3.GridLines = true;
            listView3.Location = new Point(0, 0);
            listView3.Name = "listView3";
            listView3.Size = new Size(537, 375);
            listView3.TabIndex = 0;
            listView3.UseCompatibleStateImageBehavior = false;
            listView3.View = View.Details;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Username";
            columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Ruolo";
            columnHeader6.Width = 150;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Trofei";
            columnHeader7.Width = 100;
            // 
            // troopsListView
            // 
            troopsListView.Dock = DockStyle.Fill;
            troopsListView.Location = new Point(0, 0);
            troopsListView.Name = "troopsListView";
            troopsListView.Size = new Size(227, 600);
            troopsListView.TabIndex = 0;
            troopsListView.UseCompatibleStateImageBehavior = false;
            // 
            // Laboratorio
            // 
            Laboratorio.Dock = DockStyle.Fill;
            Laboratorio.Location = new Point(0, 0);
            Laboratorio.Name = "Laboratorio";
            Laboratorio.Size = new Size(214, 163);
            Laboratorio.TabIndex = 0;
            Laboratorio.TabStop = false;
            Laboratorio.Text = "Laboratorio";
            // 
            // VillagePanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(leftSplitContainer);
            MinimumSize = new Size(1000, 600);
            Name = "VillagePanel";
            Size = new Size(1000, 600);
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
            attacksTab.ResumeLayout(false);
            clanTab.ResumeLayout(false);
            clanTabSplitContainer.Panel1.ResumeLayout(false);
            clanTabSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)clanTabSplitContainer).EndInit();
            clanTabSplitContainer.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }
    }
}
