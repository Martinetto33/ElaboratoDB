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
        private readonly IList<Troop> _upgradingTroops = [];
        public IList<Troop> UpgradingTroops { get; set; } = [];

        public async Task UpgradeTroop(Troop troop)
        {
            UpgradingTroops.Add(troop); // used only to allow external interrogations
            _upgradingTroops.Add(troop);
            // Wait for the troop to upgrade; each upgrade takes 5 seconds per level.
            foreach (Troop upgradingTroop in _upgradingTroops)
            {
                await upgradingTroop.UpgradeAsync(upgradingTroop.Level * Configuration.UPGRADE_TIME_PER_LEVEL);
                UpgradingTroops.Remove(upgradingTroop);
            }
            _upgradingTroops.Clear();
        }
    }
}
