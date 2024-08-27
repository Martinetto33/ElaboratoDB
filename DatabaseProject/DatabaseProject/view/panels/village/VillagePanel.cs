using DatabaseProject.common;
using DatabaseProject.daos;
using DatabaseProject.mapper;
using DatabaseProject.model.api;
using DatabaseProject.model.code;
using DatabaseProject.view.images;
using DatabaseProject.view.panels.account;

namespace DatabaseProject.view.panels.village
{
    public partial class VillagePanel : UserControl
    {
        public Account Account { get; }
        public Player Player { get; }
        public Village Village { get; set; }
        public List<Attack> Attacks { get; }
        public Clan? Clan { get; }
        public List<IUpgradeObservable<BaseBuilding>> Builders { get; set; } = [];
        public IUpgradeObservable<Troop> Laboratory { get; set; }
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

            // Inserting the images in the buildings and troops panel
            this.buildingsListView.LargeImageList = ImageLoader.GetBuildingsImageList(new Size(50, 50));
            this.troopsListView.LargeImageList = ImageLoader.GetTroopsImageList(new Size(50, 50));

            UpdateBuildingsPanel();
            UpdateTroopsPanel();
            UpdateAttacksPanel();
            UpdateClanPanel();
        }

        private void CreateAndRegisterObservers()
        {
            laboratoryObserver = new UpgradeObserverImpl<Troop>(upgradedTroop =>
            {
                UpgradesDao.RegisterTroopUpgrade(DatabaseToModelMapper.Unmap(upgradedTroop), Guid.Parse(this.Village.VillageId));
                // Before refreshing, we need to make sure that no other upgrades are in progress!
                RefreshVillagePanel();
            });
            Laboratory.RegisterObserver(laboratoryObserver);
            builderObservers = [];
            foreach (var builder in Builders)
            {
                var builderObserver = new UpgradeObserverImpl<BaseBuilding>(upgradedBuilding =>
                {
                    //this.Village = DatabaseToModelMapper.Map
                    //(
                    //    Transactions.UpgradeBuildingAndRetrieveVillage
                    //    (
                    //        DatabaseToModelMapper.Unmap(upgradedBuilding, this.Village),
                    //        Guid.Parse(this.Village.VillageId),
                    //        Int32.Parse(builder.GetObservableId()),
                    //        Guid.Parse(this.Account.Id)
                    //    )
                    //);
                    //UpgradesDao.RegisterBuildingUpgrade(
                    //    DatabaseToModelMapper.Unmap(upgradedBuilding, this.Village),
                    //    Guid.Parse(this.Village.VillageId),
                    //    Int32.Parse(builder.GetObservableId())
                    //    );
                    Transactions.RegisterBuildingUpgradeWithCallback
                    (
                        DatabaseToModelMapper.Unmap(upgradedBuilding, this.Village),
                        Guid.Parse(this.Village.VillageId),
                        Int32.Parse(builder.GetObservableId()),
                        () => RefreshVillagePanel()
                    );
                    // Before refreshing, we need to make sure that no other upgrades are in progress!
                    RefreshVillagePanel();
                });
                builder.RegisterObserver(builderObserver);
                builderObservers.Add(builderObserver);
            }
        }

        // Call this method when moving to another panel
        private void ClearObservers()
        {
            Laboratory.RemoveObserver(laboratoryObserver);
            foreach (var builder in Builders)
            {
                builderObservers.ForEach(observer => builder.RemoveObserver(observer));
            }
        }

        private void RefreshVillagePanel()
        {
            ClearObservers();
            this.Village = DatabaseToModelMapper.Map(VillageDao.GetVillageFromAccountId(Guid.Parse(Account.Id))!);

            // Debug, throw away
            foreach (var item in Village.SpecialBuildings)
            {
                Console.WriteLine($"Building: {item.Name}, Level: {item.Level}");
            }
            // end debug

            this.Builders.Clear();
            foreach (var item in Village.Builders)
            {
                this.Builders.Add(item);
            }
            this.Laboratory = Village.Laboratory;
            CreateAndRegisterObservers();
            UpdateBuildingsPanel();
            UpdateBuildersPanel(Builders);
            UpdateLaboratoryPanel(Laboratory);
            UpdateTroopsPanel();
            UpdateMainLabels();
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

        private void UpdateMainLabels()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(UpdateMainLabels));
            }
            else
            {
                playerNameLabel.Text = $"Giocatore: {Player.Name} {Player.Surname}";
                accountUsernameLabel.Text = $"Account: {Account.Username}";
                forceLabel.Text = $"Forza: {Village.Strength}%";
                trophiesLabel.Text = $"Trofei: {Village.Trophies}";
                starsLabel.Text = $"Stelle: {Village.WarStars}";
                xpLabel.Text = $"XP: {Village.ExperienceLevel}";
            }
        }

        public void AddBuildingToView(BaseBuilding building)
        {
            var imageIndex = ImageLoader.GetIndexFromDatabaseBuildingName(building.Name);
            var listItem = new ListViewItem
            {
                Text = $"{building.Name} - Lv{building.Level}",
                ImageIndex = (int)imageIndex,
            };
            Enums.BuildingType type = building.BuildingType;
            switch (type)
            {
                case Enums.BuildingType.Defense:
                    listItem.Group = buildingsListView.Groups[2];
                    listItem.ToolTipText =
                        $"Punti vita: {building.HealthPoints}" +
                        $"\nLivello: {building.Level}" +
                        $"\nDanni al secondo: {((Defense)building).DamagePerSecond}" +
                        $"\nNumero di bersagli: {((Defense)building).TargetsNumber}" +
                        $"\nRaggio d'attacco: {((Defense)building).AttackRange}";
                    break;
                case Enums.BuildingType.Resource:
                    listItem.Group = buildingsListView.Groups[1];
                    listItem.ToolTipText =
                        $"Punti vita: {building.HealthPoints}" +
                        $"\nLivello: {building.Level}" +
                        $"\nProduzione oraria: {((ResourceExtractor)building).ProductionRate}" +
                        $"\nTipo risorsa: {((ResourceExtractor)building).ResourceType}";
                    break;
                case Enums.BuildingType.Special:
                    listItem.Group = buildingsListView.Groups[0];
                    listItem.ToolTipText =
                        $"Punti vita: {building.HealthPoints}" +
                        $"\nLivello: {building.Level}" +
                        $"\nRuolo: {((SpecialBuilding)building).Role}" +
                        $"\nDescrizione funzione: " + ((SpecialBuilding)building).Description;
                    break;
            }
            buildingsListView.Items.Add(listItem);
            CreateBuildingMenuStrip(listItem, building);
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
                Text = $"{troop.Name} - Lv{troop.Level}",
                ImageIndex = (int)imageIndex
            };
            listItem.ToolTipText =
                $"Punti vita: {troop.HealthPoints}" +
                $"\nLivello: {troop.Level}" +
                $"\nDanni al secondo: {troop.DamagePerSecond}" +
                $"\nDescrizione: {troop.Description}";
            troopsListView.Items.Add(listItem);
            CreateTroopMenuStrip(listItem, troop);
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
            if (buildersFlowLayoutPanel.InvokeRequired)
            {
                // Allows calls from other threads
                buildersFlowLayoutPanel.Invoke(new Action(() => UpdateBuildersPanel(builders)));
                return;
            }
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
            if (laboratoryFlowLayout.InvokeRequired)
            {
                // Allows calls from other threads
                laboratoryFlowLayout.Invoke(new Action(() => UpdateLaboratoryPanel(laboratory)));
                return;
            }
            laboratoryFlowLayout.Controls.Clear();
            if (laboratory.IsBusy())
            {
                laboratoryFlowLayout.Controls.Add(new UpgradingTroopControl($"Laboratorio: {laboratory.GetUpgradingObjectName()}", laboratory));
            }
            else
            {
                laboratoryFlowLayout.Controls.Add(new Label()
                {
                    Text = "Laboratorio: Libero",
                    AutoSize = false,
                    Width = Laboratorio.Width
                });
            }
        }

        private void UpdateBuildingsPanel()
        {
            if (buildingsListView.InvokeRequired)
            {
                // Used to handle calls from other threads
                buildingsListView.Invoke(new Action(UpdateBuildingsPanel));
            }
            else
            {
                buildingsListView.Items.Clear();
                Village.SpecialBuildings.ToList().ForEach(specialBuilding => AddBuildingToView(specialBuilding));
                Village.Extractors.ToList().ForEach(extractor => AddBuildingToView(extractor));
                Village.Defenses.ToList().ForEach(defense => AddBuildingToView(defense));
            }
        }

        private void UpdateTroopsPanel()
        {
            if (troopsListView.InvokeRequired)
            {
                // Used to handle calls from other threads
                troopsListView.Invoke(new Action(UpdateTroopsPanel));
            }
            else
            {
                troopsListView.Items.Clear();
                Village.Troops.ToList().ForEach(troop => AddTroopToView(troop));
            }
        }

        // Navigation methods
        private void backButton_Click(object sender, EventArgs e)
        {
            this.ClearObservers();
            var mainForm = (ClashOfClansDatabaseApplication)this.Parent!;
            mainForm.LoadPanel(new AccountsPanel(Player));
        }
    }
}
