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
            leftSplitContainer = new SplitContainer();
            rightSplitContainer = new SplitContainer();
            centralSplitContainer = new SplitContainer();
            leftPanelsSplitContainer = new SplitContainer();
            buildersAndLaboratorySplitContainer = new SplitContainer();
            tabControl1 = new TabControl();
            villageTab = new TabPage();
            attacksTab = new TabPage();
            clanTab = new TabPage();
            flowLayoutPanel1 = new FlowLayoutPanel();
            forceLabel = new Label();
            trophiesLabel = new Label();
            starsLabel = new Label();
            xpLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)leftSplitContainer).BeginInit();
            leftSplitContainer.Panel1.SuspendLayout();
            leftSplitContainer.Panel2.SuspendLayout();
            leftSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rightSplitContainer).BeginInit();
            rightSplitContainer.Panel1.SuspendLayout();
            rightSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)centralSplitContainer).BeginInit();
            centralSplitContainer.Panel1.SuspendLayout();
            centralSplitContainer.Panel2.SuspendLayout();
            centralSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)leftPanelsSplitContainer).BeginInit();
            leftPanelsSplitContainer.Panel2.SuspendLayout();
            leftPanelsSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)buildersAndLaboratorySplitContainer).BeginInit();
            buildersAndLaboratorySplitContainer.SuspendLayout();
            tabControl1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
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
            // rightSplitContainer
            // 
            rightSplitContainer.Dock = DockStyle.Fill;
            rightSplitContainer.Location = new Point(0, 0);
            rightSplitContainer.Name = "rightSplitContainer";
            // 
            // rightSplitContainer.Panel1
            // 
            rightSplitContainer.Panel1.Controls.Add(centralSplitContainer);
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
            // leftPanelsSplitContainer
            // 
            leftPanelsSplitContainer.Dock = DockStyle.Fill;
            leftPanelsSplitContainer.Location = new Point(0, 0);
            leftPanelsSplitContainer.Name = "leftPanelsSplitContainer";
            leftPanelsSplitContainer.Orientation = Orientation.Horizontal;
            // 
            // leftPanelsSplitContainer.Panel2
            // 
            leftPanelsSplitContainer.Panel2.Controls.Add(buildersAndLaboratorySplitContainer);
            leftPanelsSplitContainer.Size = new Size(211, 561);
            leftPanelsSplitContainer.SplitterDistance = 148;
            leftPanelsSplitContainer.TabIndex = 0;
            // 
            // buildersAndLaboratorySplitContainer
            // 
            buildersAndLaboratorySplitContainer.Dock = DockStyle.Fill;
            buildersAndLaboratorySplitContainer.Location = new Point(0, 0);
            buildersAndLaboratorySplitContainer.Name = "buildersAndLaboratorySplitContainer";
            buildersAndLaboratorySplitContainer.Orientation = Orientation.Horizontal;
            buildersAndLaboratorySplitContainer.Size = new Size(211, 409);
            buildersAndLaboratorySplitContainer.SplitterDistance = 199;
            buildersAndLaboratorySplitContainer.TabIndex = 0;
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
            attacksTab.Size = new Size(660, 554);
            attacksTab.TabIndex = 1;
            attacksTab.Text = "Attacchi";
            attacksTab.UseVisualStyleBackColor = true;
            // 
            // clanTab
            // 
            clanTab.Location = new Point(4, 24);
            clanTab.Name = "clanTab";
            clanTab.Padding = new Padding(3);
            clanTab.Size = new Size(660, 554);
            clanTab.TabIndex = 2;
            clanTab.Text = "Clan";
            clanTab.UseVisualStyleBackColor = true;
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
            rightSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)rightSplitContainer).EndInit();
            rightSplitContainer.ResumeLayout(false);
            centralSplitContainer.Panel1.ResumeLayout(false);
            centralSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)centralSplitContainer).EndInit();
            centralSplitContainer.ResumeLayout(false);
            leftPanelsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)leftPanelsSplitContainer).EndInit();
            leftPanelsSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)buildersAndLaboratorySplitContainer).EndInit();
            buildersAndLaboratorySplitContainer.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
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
    }
}