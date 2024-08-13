using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.model
{
    internal class Laboratory(
        string buildingId,
        string villageId,
        string name,
        int level,
        int healthPoints,
        string description
    ) : SpecialBuilding(buildingId, villageId, name, level, healthPoints, description, SpecialBuildingRole.Laboratory)
    {
        public IList<Troop> UpgradingTroops { get; set; } = [];

        public async Task UpgradeTroop(Troop troop)
        {
            UpgradingTroops.Add(troop);
            // Wait for the troop to upgrade; each upgrade takes 5 seconds per level.
            foreach (Troop upgradingTroop in UpgradingTroops)
            {
                await upgradingTroop.UpgradeAsync(upgradingTroop.Level * 5);
                Console.WriteLine($"Troop {upgradingTroop.Name} has been upgraded to level {upgradingTroop.Level}.");
                UpgradingTroops.Remove(upgradingTroop);
            }
        }
    }
}
