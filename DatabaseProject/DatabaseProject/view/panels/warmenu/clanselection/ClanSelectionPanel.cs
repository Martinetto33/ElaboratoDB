using DatabaseProject.daos;
using DatabaseProject.mapper;
using DatabaseProject.model.code;
using DatabaseProject.view.panels.initialmenu;
using DatabaseProject.view.panels.warmenu.clanselection.clanlabels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.view.panels.warmenu.clanselection
{
    public partial class ClanSelectionPanel : UserControl
    {
        private Action<ClanLabel> _delegate = (selectedLabel) => { };

        public ClanSelectionPanel()
        {
            InitializeComponent();
            this._delegate = (selectedLabel) =>
            {
                selectedLabel.Selected = !selectedLabel.Selected;
                if (selectedLabel.Selected)
                {
                    this.unselectedClanLabelsFlowLayoutPanel.Controls.Remove(selectedLabel);
                    this.flowLayoutPanel1.Controls.Add(selectedLabel);
                }
                else
                {
                    this.flowLayoutPanel1.Controls.Remove(selectedLabel);
                    this.unselectedClanLabelsFlowLayoutPanel.Controls.Add(selectedLabel);
                }
            };
            CreateClanLabels();
        }

        /********* VIEW ************/
        private void CreateClanLabels()
        {
            List<Clan> allAvailableClans = ClanDao.GetClansSuitableForWar()
                .Select(clan => DatabaseToModelMapper.Map(clan))
                .ToList();
            foreach (var clan in allAvailableClans)
            {
                this.unselectedClanLabelsFlowLayoutPanel
                    .Controls
                    .Add(new ClanLabel(Guid.Parse(clan.ClanId), clan.Name, _delegate));
            }
        }

        /********* BUTTONS LOGIC ************/
        private void BackButton_Click(object sender, EventArgs e)
        {
            var mainForm = (ClashOfClansDatabaseApplication)this.Parent!;
            mainForm.LoadPanel(new InitialMenuPanel());
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            // add logic to start simulation, maybe log something in the console
        }
    }
}
