using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.model
{
    internal class Builder(string villageId, int builderId)
    {
        public string VillageId { get; } = villageId;
        public int BuilderId { get; } = builderId;
        public bool IsBusy { get; set; } = false;

        public BaseBuilding? UpgradingBuilding { get; set; } = null;

        public async Task UpgradeBuilding(BaseBuilding upgradingBuilding)
        {
            if (this.IsBusy)
            {
                Console.WriteLine($"Builder {this.BuilderId} is busy upgrading another building.");
            }
            else
            {
                this.IsBusy = true;
                this.UpgradingBuilding = upgradingBuilding;
                // Wait for the building to upgrade; each upgrade takes 5 seconds per level.
                await upgradingBuilding.UpgradeAsync(upgradingBuilding.Level * 5);
                Console.WriteLine($"Builder {this.BuilderId} has finished upgrading {upgradingBuilding.Name} to level {upgradingBuilding.Level}.");
                this.IsBusy = false;
                this.UpgradingBuilding = null;
            }
        }
    }
}
