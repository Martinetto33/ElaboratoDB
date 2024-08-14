using DatabaseProject.config;

namespace DatabaseProject.model
{
    public class Laboratory(
        string buildingId,
        string villageId,
        string name,
        int level,
        int healthPoints,
        string description
    ) : SpecialBuilding(buildingId, villageId, name, level, healthPoints, description, SpecialBuildingRole.Laboratory)
    {
        public bool IsBusy { get; set; } = false;
        public Troop? UpgradingTroop { get; set; } = null;

        public async Task UpgradeTroop(Troop troop)
        {
            if (this.IsBusy)
            {
                Console.WriteLine($"Laboratory is busy upgrading troop: {this.UpgradingTroop?.Name}.");
                throw new LaboratoryBusyException("Laboratory is busy upgrading another troop.");
            }
            this.UpgradingTroop = troop;
            this.IsBusy = true;
            // Wait for the troop to upgrade; each upgrade takes 5 seconds per level.
            await troop.UpgradeAsync(troop.Level * Configuration.UPGRADE_TIME_PER_LEVEL);
            this.UpgradingTroop = null;
            this.IsBusy = false;
        }
    }
}
