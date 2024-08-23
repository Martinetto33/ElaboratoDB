using DatabaseProject.config;
using DatabaseProject.database;

namespace DatabaseProject.model.code
{
    public enum BuildingType
    {
        Defense,
        Resource,
        Special
    }

    public enum ResourceType
    {
        Gold,
        Elixir,
        DarkElixir
    }

    public enum SpecialBuildingRole
    {
        TownHall,
        ClanCastle,
        Laboratory,
        ArmyCamp
    }
    public class BaseBuilding
    {
        public string BuildingId { get; }
        public string Name { get; }
        public int Level { get; set; }
        public int HealthPoints { get; set; }
        public BuildingType BuildingType { get; }

        protected BaseBuilding(
            string buildingId,
            string name,
            int level,
            int healthPoints,
            BuildingType type
        )
        {
            BuildingId = buildingId;
            Name = name;
            Level = level;
            HealthPoints = healthPoints;
            BuildingType = type;
        }

        /// <summary>
        /// Asynchronously upgrades the building after a specified delay.
        /// </summary>
        /// <param name="upgradeTimeInSeconds">The time in seconds to wait before upgrading.</param>
        public async virtual Task UpgradeAsync(double upgradeTimeInSeconds)
        {
            if (Level < Configuration.MAX_LEVEL)
            {
                // Simulate the time passing for the upgrade
                await Task.Delay((int)(upgradeTimeInSeconds * 1000));

                // Perform the upgrade
                Level++;
                HealthPoints += 100; // Example: Increase health points on upgrade
            }
        }
    }

    public class Defense(
        string buildingId,
        string name,
        int level,
        int healthPoints,
        double damagePerSecond,
        int targetsNumber,
        int attackRange
    ) : BaseBuilding(buildingId, name, level, healthPoints, BuildingType.Defense)
    {
        public double DamagePerSecond { get; set; } = damagePerSecond;
        public int TargetsNumber { get; set; } = targetsNumber;
        public int AttackRange { get; set; } = attackRange;

        public async override Task UpgradeAsync(double upgradeTimeInSeconds)
        {
            if (Level < Configuration.MAX_LEVEL)
            {
                await Task.Delay((int)(upgradeTimeInSeconds * 1000));
                Level++;
                HealthPoints += 100;
                DamagePerSecond += 100.0;
                if (Random.Shared.Next(0, 2) == 0)
                {
                    TargetsNumber++;
                }
                else
                {
                    AttackRange++;
                }
            }
        }
    }

    public class ResourceExtractor(
        string buildingId,
        string name,
        int level,
        int healthPoints,
        ResourceType type,
        int productionRate
    ) : BaseBuilding(buildingId, name, level, healthPoints, BuildingType.Resource)
    {
        public ResourceType ResourceType { get; } = type;
        public int ProductionRate { get; set; } = productionRate;
        public async override Task UpgradeAsync(double upgradeTimeInSeconds)
        {
            if (Level < Configuration.MAX_LEVEL)
            {
                await Task.Delay((int)(upgradeTimeInSeconds * 1000));
                Level++;
                HealthPoints += 100;
                ProductionRate += 100;
            }
        }
    }

    public class SpecialBuilding(
        string buildingId,
        string name,
        int level,
        int healthPoints,
        string description,
        SpecialBuildingRole role
    ) : BaseBuilding(buildingId, name, level, healthPoints, BuildingType.Special)
    {
        public string Description { get; } = description;
        public SpecialBuildingRole Role { get; } = role;
    }
}
