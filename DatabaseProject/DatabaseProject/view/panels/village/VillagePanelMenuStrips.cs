using DatabaseProject.config;
using DatabaseProject.model.code;

namespace DatabaseProject.view.panels.village
{
    public partial class VillagePanel
    {
        private readonly Dictionary<ListViewItem, ContextMenuStrip> buildingContextMenuStripsDictionary = [];
        private readonly Dictionary<ListViewItem, ContextMenuStrip> troopContextMenuStripsDictionary = [];
        private readonly Dictionary<ToolStripMenuItem, BaseBuilding> buildingToolStripMenuItemsDictionary = [];
        private readonly Dictionary<ToolStripMenuItem, Troop> troopToolStripMenuItemsDictionary = [];

        /// <summary>
        /// Called when the user right-clicks the troops list view.
        /// Looks for a troop at the clicked coordinates and if 
        /// present shows its relative ContextMenuStrip.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TroopsListView_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Right-clicked on troops list view.");
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem item = this.troopsListView.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    this.troopContextMenuStripsDictionary[item].Show(this.troopsListView, e.Location);
                }
            }
        }

        /// <summary>
        /// Called when the user right-clicks the buildings list view.
        /// Looks for a building at the clicked coordinates and if present
        /// shows its relative ContextMenuStrip.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildingsListView_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Right-clicked on buildings list view.");
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem item = this.buildingsListView.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    this.buildingContextMenuStripsDictionary[item].Show(this.buildingsListView, e.Location);
                }
            }
        }

        /// <summary>
        /// You should call this method when adding items to the buildings list view.
        /// Creates a ContextMenuStrip with one option, "upgrade building", for the given building.
        /// When a click is detected on the provided ListViewItem, the ContextMenuStrip will be shown.
        /// If the upgrade building button is clicked, the UpgradeBuilding_Click method will be called,
        /// and the building to upgrade will be retrieved through means of the 
        /// buildingToolStripMenuItemsDictionary.
        /// </summary>
        /// <param name="listViewItem"></param>
        /// <param name="building"></param>
        /// <returns></returns>
        private void CreateBuildingMenuStrip(ListViewItem listViewItem, BaseBuilding building)
        {
            var buildingsContextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem upgradeBuilding = new("Migliora edificio");
            upgradeBuilding.Click += new EventHandler(UpgradeBuilding_Click);
            buildingsContextMenuStrip.Items.Add(upgradeBuilding);
            if (building.Level == Configuration.MAX_LEVEL) upgradeBuilding.Enabled = false;
            this.buildingToolStripMenuItemsDictionary.Add(upgradeBuilding, building);
            this.buildingContextMenuStripsDictionary.Add(listViewItem, buildingsContextMenuStrip);
        }

        /// <summary>
        /// You should call this method when adding items to the troops list view.
        /// Creates a ContextMenuStrip with one option, "upgrade troop", for the given troop.
        /// When a click is detected on the provided ListViewItem, the ContextMenuStrip will be shown.
        /// If the upgrade troop button is clicked, the UpgradeTroop_Click method will be called,
        /// and the troop to upgrade will be retrieved through means of the 
        /// troopToolStripMenuItemsDictionary.
        /// </summary>
        /// <param name="listViewItem"></param>
        /// <param name="troop"></param>
        /// <returns></returns>
        private void CreateTroopMenuStrip(ListViewItem listViewItem, Troop troop)
        {
            var troopsContextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem upgradeTroop = new("Migliora truppa");
            upgradeTroop.Click += new EventHandler(UpgradeTroop_Click);
            troopsContextMenuStrip.Items.Add(upgradeTroop);
            if (troop.Level == Configuration.MAX_LEVEL) upgradeTroop.Enabled = false;
            this.troopToolStripMenuItemsDictionary.Add(upgradeTroop, troop);
            this.troopContextMenuStripsDictionary.Add(listViewItem, troopsContextMenuStrip);
        }

        /// <summary>
        /// Called when the user clicks the "Migliora edificio" button in the ContextMenuStrip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpgradeBuilding_Click(object sender, EventArgs e)
        {
            var menuItem = (ToolStripMenuItem)sender;
            var building = this.buildingToolStripMenuItemsDictionary[menuItem];
            var freeBuilder = this.Builders.Find(b => b.CanUpgrade(building));
            if (freeBuilder != null)
            {
                ((Builder)freeBuilder).UpgradeBuilding(building);
                UpdateBuildersPanel(this.Builders);
            }
            else
            {
                MessageBox.Show("Costruttori occupati o edificio già al livello massimo.");
            }
        }

        /// <summary>
        /// Called when the user clicks the "Migliora truppa" button in the ContextMenuStrip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpgradeTroop_Click(object sender, EventArgs e)
        {
            var menuItem = (ToolStripMenuItem)sender;
            var troop = this.troopToolStripMenuItemsDictionary[menuItem];
            if (this.Laboratory.CanUpgrade(troop))
            {
                ((Laboratory)this.Laboratory).UpgradeTroop(troop);
                UpdateLaboratoryPanel(this.Laboratory);
            }
            else
            {
                MessageBox.Show("Laboratorio occupato o truppa già al livello massimo.");
            }
        }
    }
}
