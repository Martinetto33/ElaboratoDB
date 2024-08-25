using DatabaseProject.model.code;
using System;
namespace DatabaseProject.view.panels.village
{
    public partial class TestUpgradeForm : Form
    {
        public TestUpgradeForm()
        {
            InitializeComponent();
            var builder = new Builder(0);
            var buildingToUpgrade = new Defense(123, "Cannone", 4, 100, 20.0, 1, 10);
            builder.UpgradeBuilding(buildingToUpgrade);
            this.Controls.Add(new UpgradingBuildingControl($"Costruttore {builder.GetObservableId()}: {builder.GetUpgradingObjectName()}", builder));
        }
    }
}
