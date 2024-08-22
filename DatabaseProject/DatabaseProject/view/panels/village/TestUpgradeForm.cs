using DatabaseProject.model.code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseProject.view.panels.village
{
    public partial class TestUpgradeForm : Form
    {
        public TestUpgradeForm()
        {
            InitializeComponent();
            var builder = new Builder("123", 0);
            var buildingToUpgrade = new Defense("123", "123", "Cannone", 4, 100, 20.0, 1, 10);
            builder.UpgradeBuilding(buildingToUpgrade);
            this.Controls.Add(new UpgradingBuildingControl($"Costruttore {builder.GetObservableId()}: {builder.GetUpgradingObjectName()}", builder));
        }
    }
}
