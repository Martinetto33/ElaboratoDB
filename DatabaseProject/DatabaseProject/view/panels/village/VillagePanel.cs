using DatabaseProject.database;
using DatabaseProject.model.api;
using DatabaseProject.model.code;
using DatabaseProject.view.images;

namespace DatabaseProject.view.panels.village
{
    public partial class VillagePanel : UserControl
    {
        public database.Account Account { get; }
        public Giocatore Player { get { return Account.IdGiocatoreNavigation; } }
        public Villaggio Village { get { return Account.IdVillaggioNavigation; } }
        public List<IUpgradeObservable<BaseBuilding>> Builders { get; }
        public IUpgradeObservable<Troop> Laboratory { get; }
        private readonly UpgradeObserverImpl<Troop> laboratoryObserver;
        private readonly List<UpgradeObserverImpl<BaseBuilding>> builderObservers;

        public VillagePanel(database.Account account, List<IUpgradeObservable<BaseBuilding>> builders, IUpgradeObservable<Troop> laboratory)
        {
            Account = account;
            InitializeComponent();
            Builders = builders;
            Laboratory = laboratory;
            laboratoryObserver = new UpgradeObserverImpl<Troop>(upgradedTroop =>
            {
                AddTroopToView(upgradedTroop);
            });
            laboratory.RegisterObserver(laboratoryObserver);
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
            UpdateBuildersPanel(Builders);
            UpdateLaboratoryPanel(Laboratory);
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

        public void AddBuildingToView(Edificio building)
        {
            var imageIndex = ImageLoader.GetIndexFromDatabaseBuildingName(building.Nome);
            var listItem = new ListViewItem
            {
                Text = building.Nome,
                ImageIndex = (int)imageIndex
            };
            BuildingType type = Enum.Parse<BuildingType>(building.Tipo);
            switch (type)
            {
                case BuildingType.Defense:
                    listItem.Group = listView1.Groups[2];
                    break;
                case BuildingType.Resource:
                    listItem.Group = listView1.Groups[1];
                    break;
                case BuildingType.Special:
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
        /// Adds an attack to the list view in the attacks tab.
        /// </summary>
        /// <param name="attack"></param>
        /// <param name="trophiesForAttack"></param>
        /// <param name="attackType">A string describing if this attack was actually an attack or a defense.</param>
        public void AddAttackToView(Attacco attack, int trophiesForAttack, string attackType)
        {
            var listItem = new ListViewItem
            {
                Text = attack.StelleOttenute.ToString(),
                SubItems = { attack.PercentualeDistruzione.ToString(), attack.TempoImpiegato.ToString(), trophiesForAttack.ToString(), attackType }
            };
            listView2.Items.Add(listItem);
        }

        public void UpdateBuildersPanel(List<IUpgradeObservable<BaseBuilding>> builders)
        {
            Costruttori.Controls.Clear();
            builders.ForEach(builder =>
            {
                if (builder.IsBusy())
                {
                    Costruttori.Controls.Add(new UpgradingBuildingControl($"Costruttore {builder.GetObservableId()}: {builder.GetUpgradingObjectName()}", builder));
                }
                else
                {
                    Costruttori.Controls.Add(new Label()
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
    }
}
