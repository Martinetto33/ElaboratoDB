using DatabaseProject.common;
using DatabaseProject.daos;
using DatabaseProject.mapper;
using DatabaseProject.model.api;
using DatabaseProject.model.code;
using DatabaseProject.view.images;

namespace DatabaseProject.view.panels.village
{
    public partial class VillagePanel : UserControl
    {
        public Account Account { get; }
        public Player Player { get; }
        public Village Village { get; }
        public List<Attack> Attacks { get; }
        public Clan? Clan { get; }
        public List<IUpgradeObservable<BaseBuilding>> Builders { get; } = [];
        public IUpgradeObservable<Troop> Laboratory { get; }
        private UpgradeObserverImpl<Troop> laboratoryObserver = null!;
        private List<UpgradeObserverImpl<BaseBuilding>> builderObservers = null!;

        /// <summary>
        /// Needs model entities to build the complex village panel.
        /// </summary>
        /// <param name="account">The current account, that needs to have its Player and Village properties set.
        /// The Clan can be null.</param>
        /// <param name="attacksMadeAndUndergone"></param>
        /// <exception cref="NullReferenceException"></exception>
        public VillagePanel(Account account, List<Attack> attacksMadeAndUndergone)
        {
            Account = account;
#pragma warning disable S112 // General or reserved exceptions should never be thrown
            Player = DatabaseToModelMapper.Map(PlayerDao.GetPlayerFromAccountId(Guid.Parse(account.Id)));
            Village = account.Village ?? throw new NullReferenceException("Village was null!");
#pragma warning restore S112 // General or reserved exceptions should never be thrown
            Village.UpdateStrength(attacksMadeAndUndergone
                .Where(attack => attack.GetAttackType(account) == Enums.AccountRoleInAttack.Attacker)
                .ToList()
                .Count);
            if (ClanDao.IsAccountInClan(Guid.Parse(account.Id)))
            {
                Clan = DatabaseToModelMapper.Map(ClanDao.GetClanFromAccountId(Guid.Parse(account.Id))!);
            } 
            else
            {
                Clan = null;
            }
            Attacks = attacksMadeAndUndergone;
            InitializeComponent();
            foreach (var builder in Village.Builders)
            {
                Builders.Add(builder);
            }
            Laboratory = Village.Laboratory;
            CreateAndRegisterObservers();
            UpdateBuildersPanel(Builders);
            UpdateLaboratoryPanel(Laboratory);
            UpdateMainLabels();
            // TODO: finish initialising the panels and the list views; manage the case of a null Clan.
            UpdateAttacksPanel();
            UpdateClanPanel();
        }

        private void UpdateClanPanel()
        {
            if (this.Clan != null)
            {
                this.clanNameLabel.Text = $"Clan: {this.Clan.Name}";
                this.clanRoleLabel.Text = $"Ruolo: {this.Clan.Members[this.Account.Id]}";
                this.membersNumberLabel.Text = $"Membri: {this.Clan.Members.Count}/50";
                this.clanTrophiesLabel.Text = $"Trofei: {this.Clan.TotalTrophies}";
                this.clanStarsLabel.Text = $"Stelle: {this.Clan.TotalStarsWon}";
                // Populating the members
                var clanMembersList = this.Clan.Members.Keys.ToList();
                // Sorting the members by trophies; may throw NullReferenceException if a member has no village.
                clanMembersList.Sort((m1, m2) =>
                {
                    var v1 = DatabaseToModelMapper.Map(VillageDao.GetVillageFromAccountId(Guid.Parse(m1))!);
                    var v2 = DatabaseToModelMapper.Map(VillageDao.GetVillageFromAccountId(Guid.Parse(m2))!);
                    return v2.Trophies.CompareTo(v1.Trophies);
                });
                clanMembersList.Select(accountIdString 
                    => DatabaseToModelMapper.Map(AccountDao.GetAccountFromId(Guid.Parse(accountIdString))!))
                    .ToList()
                    .ForEach(member =>
                {
                    var listItem = new ListViewItem
                    {
                        Text = member.Username,
                        SubItems = { this.Clan.Members[member.Id.ToString()].ToString(), member.Village!.Trophies.ToString() }
                    };
                    this.listView3.Items.Add(listItem);
                });
            } 
            else
            {
                this.clanNameLabel.Text = "Clan: Nessuno";
                this.clanRoleLabel.Text = "Ruolo: Nessuno";
                this.membersNumberLabel.Text = "Membri: Nessuno";
                this.clanTrophiesLabel.Text = $"Trofei: Nessuno";
                this.clanStarsLabel.Text = $"Stelle: Nessuna";
            }
        }

        private void UpdateAttacksPanel() => Attacks.ForEach(attack => AddAttackToView(attack));

        private void CreateAndRegisterObservers()
        {
            laboratoryObserver = new UpgradeObserverImpl<Troop>(upgradedTroop =>
            {
                AddTroopToView(upgradedTroop);
            });
            Laboratory.RegisterObserver(laboratoryObserver);
            builderObservers = [];
            foreach (var builder in Builders)
            {
                var builderObserver = new UpgradeObserverImpl<BaseBuilding>(upgradedBuilding =>
                {
                    UpdateBuildersPanel(Builders);
                });
                builder.RegisterObserver(builderObserver);
                builderObservers.Add(builderObserver);
            }
        }

        private void UpdateMainLabels()
        {
            playerNameLabel.Text = $"Giocatore: {Player.Name} {Player.Surname}";
            accountUsernameLabel.Text = $"Account: {Account.Username}";
            forceLabel.Text = $"Forza: {Village.Strength}%";
            trophiesLabel.Text = $"Trofei: {Village.Trophies}";
            starsLabel.Text = $"Stelle: {Village.WarStars}";
            xpLabel.Text = $"XP: {Village.ExperienceLevel}";
        }

        // TODO: Call this method when moving to another panel
        private void ClearObservers()
        {
            Laboratory.RemoveObserver(laboratoryObserver);
            foreach (var builder in Builders)
            {
                builderObservers.ForEach(observer => builder.RemoveObserver(observer));
            }
        }

        public void AddBuildingToView(BaseBuilding building)
        {
            var imageIndex = ImageLoader.GetIndexFromDatabaseBuildingName(building.Name);
            var listItem = new ListViewItem
            {
                Text = building.Name,
                ImageIndex = (int)imageIndex
            };
            Enums.BuildingType type = building.BuildingType;
            switch (type)
            {
                case Enums.BuildingType.Defense:
                    listItem.Group = listView1.Groups[2];
                    break;
                case Enums.BuildingType.Resource:
                    listItem.Group = listView1.Groups[1];
                    break;
                case Enums.BuildingType.Special:
                    listItem.Group = listView1.Groups[0];
                    break;
            }
            listView1.Items.Add(listItem);
        }

        /// <summary>
        /// Looks for an ImageIndex in the ImageList of the ListView control that corresponds to the name of the troop.
        /// Ensure that the name of the troop is listed in the ImageLoader class.
        /// </summary>
        /// <param name="troop">A model representation of a <see cref="Truppa"/>.</param>
        public void AddTroopToView(Troop troop)
        {
            // The following line will throw a KeyNotFoundException if the troop name is not found in the ImageLoader class.
            var imageIndex = ImageLoader.GetIndexFromDatabaseTroopName(troop.Name);
            var listItem = new ListViewItem
            {
                Text = troop.Name,
                ImageIndex = (int)imageIndex
            };
            troopsListView.Items.Add(listItem);
        }

        /// <summary>
        /// Adds an attack to the list view in the attacksMadeAndUndergone tab.
        /// </summary>
        /// <param name="attack"></param>
        /// <param name="trophiesForAttack"></param>
        /// <param name="attackType">A string describing if this attack was actually an attack or a defense.</param>
        public void AddAttackToView(Attack attack)
        {
            var listItem = new ListViewItem
            {
                Text = attack.ObtainedStars.ToString(),
                //SubItems = { attack.ObtainedPercentage.ToString(), attack.TimeTakenMS.ToString(), attack.ObtainedTrophies.ToString()/*TODO: , attack.GetAttackTypeFromAccountPerspective(this.Account)*/ }
            };
            listView2.Items.Add(listItem);
        }

        public void UpdateBuildersPanel(List<IUpgradeObservable<BaseBuilding>> builders)
        {
            buildersFlowLayoutPanel.Controls.Clear();
            builders.ForEach(builder =>
            {
                if (builder.IsBusy())
                {
                    buildersFlowLayoutPanel.Controls.Add(new UpgradingBuildingControl($"Costruttore {builder.GetObservableId()}: {builder.GetUpgradingObjectName()}", builder));
                }
                else
                {
                    buildersFlowLayoutPanel.Controls.Add(new Label()
                    {
                        Text = $"Costruttore {builder.GetObservableId()}: Libero",
                        AutoSize = false,
                        Width = Costruttori.Width
                    });
                }
            });
        }

        public void UpdateLaboratoryPanel(IUpgradeObservable<Troop> laboratory)
        {
            if (laboratory.IsBusy())
            {
                Laboratorio.Controls.Add(new UpgradingTroopControl($"Laboratorio: {laboratory.GetUpgradingObjectName()}", laboratory));
            }
            else
            {
                Laboratorio.Controls.Add(new Label()
                {
                    Text = "Laboratorio: Libero",
                    AutoSize = false,
                    Width = Laboratorio.Width
                });
            }
        }

        // Navigation methods
        private void backButton_Click(object sender, EventArgs e)
        {
            this.ClearObservers();
            var mainForm = (ClashOfClansDatabaseApplication)this.Parent!;
            //mainForm.LoadPanel(new AccountsPanel(Player)); TODO: need to switch to model entities!
        }
    }
}
