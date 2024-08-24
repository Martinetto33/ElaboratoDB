using DatabaseProject.config;
using DatabaseProject.common;

namespace DatabaseProject.model.code
{
    public class BaseBuilding
    {
        public int BuildingId { get; }
        public string Name { get; }
        public int Level { get; set; }
        public int HealthPoints { get; set; }
        public Enums.BuildingType BuildingType { get; }

        protected BaseBuilding(
            int buildingId,
            string name,
            int level,
            int healthPoints,
            Enums.BuildingType type
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
        int buildingId,
        string name,
        int level,
        int healthPoints,
        double damagePerSecond,
        int targetsNumber,
        int attackRange
    ) : BaseBuilding(buildingId, name, level, healthPoints, Enums.BuildingType.Defense)
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
        int buildingId,
        string name,
        int level,
        int healthPoints,
        Enums.ResourceType type,
        int productionRate
    ) : BaseBuilding(buildingId, name, level, healthPoints, Enums.BuildingType.Resource)
    {
        public Enums.ResourceType ResourceType { get; } = type;
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
        int buildingId,
        string name,
        int level,
        int healthPoints,
        string description,
        Enums.SpecialBuildingRole role
    ) : BaseBuilding(buildingId, name, level, healthPoints, Enums.BuildingType.Special)
    {
        public string Description { get; } = description;
        public Enums.SpecialBuildingRole Role { get; } = role;
    }
}
