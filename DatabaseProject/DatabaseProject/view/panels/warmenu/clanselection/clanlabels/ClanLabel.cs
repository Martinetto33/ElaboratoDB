using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.view.panels.warmenu.clanselection.clanlabels
{
    public class ClanLabel : UserControl
    {
        public Guid ClanGuid { get; }
        public string ClanName { get; }
        public bool Selected { get; set; }
        private readonly Action<ClanLabel> _action;
        public ClanLabel(Guid clanGuid, string clanName, Action<ClanLabel> callback)
        {
            ClanGuid = clanGuid;
            ClanName = clanName;
            InitializeComponent();
            Selected = false;
            this.label1!.Text = clanName;
            _action = callback;
        }

        private Label label1;

        private void InitializeComponent()
        {
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Teal;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.FlatStyle = FlatStyle.Popup;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(15, 15);
            label1.Name = "label1";
            label1.Size = new Size(90, 23);
            label1.TabIndex = 0;
            label1.Text = "Nome Clan";
            label1.Click += onClick;
            // 
            // ClanLabel
            // 
            Controls.Add(label1);
            Name = "ClanLabel";
            ResumeLayout(false);
            PerformLayout();
        }

        private void onClick(object sender, EventArgs e) => _action.Invoke(this);
    }
}
