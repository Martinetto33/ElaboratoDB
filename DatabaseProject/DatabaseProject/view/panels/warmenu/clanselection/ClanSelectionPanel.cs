using DatabaseProject.daos;
using DatabaseProject.mapper;
using DatabaseProject.model.code;
using DatabaseProject.simulator;
using DatabaseProject.view.panels.initialmenu;
using DatabaseProject.view.panels.warmenu.clanselection.clanlabels;
using DatabaseProject.view.panels.warmenu.warrecap;
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
            this.confirmButton.Enabled = false;
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
                if (this.flowLayoutPanel1.Controls.Count == 2)
                {
                    this.confirmButton.Enabled = true;
                }
                else
                {
                    this.confirmButton.Enabled = false;
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
            ClanLabel clanLabel1 = (this.flowLayoutPanel1.Controls[0] as ClanLabel);
            ClanLabel clanLabel2 = (this.flowLayoutPanel1.Controls[1] as ClanLabel);
            Guid clan1Id = clanLabel1.ClanGuid;
            Guid clan2Id = clanLabel2.ClanGuid;
            List<Account> clan1Accounts = AccountDao.GetAllAccountsInClan(clan1Id)
                .Select(accountAndRolePair => DatabaseToModelMapper.Map(accountAndRolePair.Key))
                .ToList();
            List<Account> clan2Accounts = AccountDao.GetAllAccountsInClan(clan2Id)
                .Select(accountAndRolePair => DatabaseToModelMapper.Map(accountAndRolePair.Key))
                .ToList();
            int clan1Members = clan1Accounts.Count;
            int clan2Members = clan2Accounts.Count;
            int numberOfWarriors = Math.Min(clan1Members - (clan1Members % 5), clan2Members - (clan2Members % 5));
            DialogResult result = MessageBox
                .Show($"La guerra tra i clan {clanLabel1.ClanName} e {clanLabel2.ClanName} inizierà con {numberOfWarriors} guerrieri per clan! Confermare?", 
                        "Inizio guerra", 
                        MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Random random = new();
                List<Account> clan1Warriors = [];
                List<Account> clan2Warriors = [];
                for (int i = 0; i < numberOfWarriors; i++)
                {
                    int clan1WarriorIndex = random.Next(0, clan1Accounts.Count);
                    int clan2WarriorIndex = random.Next(0, clan2Accounts.Count);
                    clan1Warriors.Add(clan1Accounts[clan1WarriorIndex]);
                    clan2Warriors.Add(clan2Accounts[clan2WarriorIndex]);
                    clan1Accounts.RemoveAt(clan1WarriorIndex);
                    clan2Accounts.RemoveAt(clan2WarriorIndex);
                }
                Clan clan1 = DatabaseToModelMapper.Map(ClanDao.GetClan(clan1Id));
                Clan clan2 = DatabaseToModelMapper.Map(ClanDao.GetClan(clan2Id));
                WarSimulator simulator = new(clan1, clan2, clan1Warriors, clan2Warriors);
                if (!simulator.CanStartWar()) throw new InvalidOperationException("War could not be started.");
                simulator.LaunchSimulation();
                NavigateToRecapPanel(simulator.GetWarRecap());
            }
        }

        private void NavigateToRecapPanel(WarRecap recap)
        {
            var mainForm = (ClashOfClansDatabaseApplication)this.Parent!;
            mainForm.LoadPanel(new WarRecapPanel(recap));
        }
    }
}
