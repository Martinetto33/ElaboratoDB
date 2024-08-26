using DatabaseProject.Properties;

namespace DatabaseProject.view.panels.clandetails
{
    public partial class ClanDetailsPanel
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
            BackButton = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            clanLabel = new Label();
            trophiesLabel = new Label();
            starsLabel = new Label();
            button1 = new Button();
            removeMemberButton = new Button();
            promoteMemberButton = new Button();
            demoteMemberButton = new Button();
            membersListView = new ListView();
            clanMemberColumn = new ColumnHeader();
            clanRoleColumn = new ColumnHeader();
            trophiesColumn = new ColumnHeader();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // BackButton
            // 
            BackButton.Image = Resources.back_arrow;
            BackButton.Location = new Point(18, 12);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(50, 50);
            BackButton.TabIndex = 1;
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.BackColor = Color.FromArgb(55, 115, 74);
            flowLayoutPanel1.Controls.Add(clanLabel);
            flowLayoutPanel1.Controls.Add(trophiesLabel);
            flowLayoutPanel1.Controls.Add(starsLabel);
            flowLayoutPanel1.Location = new Point(85, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(482, 50);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // clanLabel
            // 
            clanLabel.AutoSize = true;
            clanLabel.BackColor = Color.FromArgb(192, 192, 0);
            clanLabel.Font = new Font("Segoe UI", 20F);
            clanLabel.Location = new Point(3, 0);
            clanLabel.Name = "clanLabel";
            clanLabel.Size = new Size(216, 37);
            clanLabel.TabIndex = 3;
            clanLabel.Text = "Clan: Nome Clan";
            // 
            // trophiesLabel
            // 
            trophiesLabel.AutoSize = true;
            trophiesLabel.BackColor = Color.FromArgb(192, 192, 0);
            trophiesLabel.Location = new Point(225, 0);
            trophiesLabel.Name = "trophiesLabel";
            trophiesLabel.Size = new Size(78, 15);
            trophiesLabel.TabIndex = 4;
            trophiesLabel.Text = "Trofei totali: 0";
            // 
            // starsLabel
            // 
            starsLabel.AutoSize = true;
            starsLabel.BackColor = Color.FromArgb(192, 192, 0);
            starsLabel.Location = new Point(309, 0);
            starsLabel.Name = "starsLabel";
            starsLabel.Size = new Size(77, 15);
            starsLabel.TabIndex = 5;
            starsLabel.Text = "Stelle totali: 0";
            // 
            // button1
            // 
            button1.Location = new Point(43, 95);
            button1.Name = "button1";
            button1.Size = new Size(120, 27);
            button1.TabIndex = 4;
            button1.Text = "Nuovo membro";
            button1.UseVisualStyleBackColor = true;
            button1.Click += AddMemberButton_Click;
            // 
            // removeMemberButton
            // 
            removeMemberButton.Location = new Point(169, 95);
            removeMemberButton.Name = "removeMemberButton";
            removeMemberButton.Size = new Size(120, 27);
            removeMemberButton.TabIndex = 5;
            removeMemberButton.Text = "Rimuovi membro";
            removeMemberButton.UseVisualStyleBackColor = true;
            removeMemberButton.Click += RemoveMemberButton_Click;
            // 
            // promoteMemberButton
            // 
            promoteMemberButton.Location = new Point(295, 95);
            promoteMemberButton.Name = "promoteMemberButton";
            promoteMemberButton.Size = new Size(120, 27);
            promoteMemberButton.TabIndex = 6;
            promoteMemberButton.Text = "Promuovi membro";
            promoteMemberButton.UseVisualStyleBackColor = true;
            promoteMemberButton.Click += PromoteMemberButton_Click;
            // 
            // demoteMemberButton
            // 
            demoteMemberButton.Location = new Point(421, 95);
            demoteMemberButton.Name = "demoteMemberButton";
            demoteMemberButton.Size = new Size(120, 27);
            demoteMemberButton.TabIndex = 7;
            demoteMemberButton.Text = "Retrocedi membro";
            demoteMemberButton.UseVisualStyleBackColor = true;
            demoteMemberButton.Click += DemoteMemberButton_Click;
            // 
            // membersListView
            // 
            membersListView.Columns.AddRange(new ColumnHeader[] { clanMemberColumn, clanRoleColumn, trophiesColumn });
            membersListView.FullRowSelect = true;
            membersListView.GridLines = true;
            membersListView.Location = new Point(22, 137);
            membersListView.Name = "membersListView";
            membersListView.Size = new Size(540, 303);
            membersListView.TabIndex = 8;
            membersListView.UseCompatibleStateImageBehavior = false;
            membersListView.View = View.Details;
            membersListView.SelectedIndexChanged += ListView1_SelectedIndexChanged;
            // 
            // clanMemberColumn
            // 
            clanMemberColumn.Text = "Membro";
            clanMemberColumn.Width = 200;
            // 
            // clanRoleColumn
            // 
            clanRoleColumn.Text = "Ruolo";
            clanRoleColumn.Width = 100;
            // 
            // trophiesColumn
            // 
            trophiesColumn.Text = "Trofei";
            trophiesColumn.Width = 100;
            // 
            // ClanDetailsPanel
            // 
            Controls.Add(membersListView);
            Controls.Add(button1);
            Controls.Add(removeMemberButton);
            Controls.Add(promoteMemberButton);
            Controls.Add(demoteMemberButton);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(BackButton);
            Name = "ClanDetailsPanel";
            Size = new Size(584, 461);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        private Button BackButton;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label clanLabel;
        private Label trophiesLabel;
        private Label starsLabel;
        private Button button1;
        private Button removeMemberButton;
        private Button promoteMemberButton;
        private Button demoteMemberButton;
        private ListView membersListView;
        private ColumnHeader clanMemberColumn;
        private ColumnHeader clanRoleColumn;
        private ColumnHeader trophiesColumn;
    }
}
