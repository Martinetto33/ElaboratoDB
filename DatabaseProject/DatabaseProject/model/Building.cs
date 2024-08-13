﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.model
{
    enum BuildingType
    {
        Defense,
        Resource,
        Special
    }

    enum ResourceType
    {
        Gold,
        Elixir,
        DarkElixir
    }

    enum SpecialBuildingRole
    {
        TownHall,
        ClanCastle,
        Laboratory,
        ArmyCamp
    }
    internal class BaseBuilding
    {
        public string BuildingId { get; }
        public string VillageId { get; }
        public string Name { get; }
        public int Level { get; set; }
        public int HealthPoints { get; set; }
        public BuildingType BuildingType { get; }

        protected BaseBuilding(
            string buildingId,
            string villageId,
            string name,
            int level,
            int healthPoints,
            BuildingType type
        )
        {
            this.BuildingId = buildingId;
            this.VillageId = villageId;
            this.Name = name;
            this.Level = level;
            this.HealthPoints = healthPoints;
            this.BuildingType = type;
        }

        /// <summary>
        /// Asynchronously upgrades the building after a specified delay.
        /// </summary>
        /// <param name="upgradeTimeInSeconds">The time in seconds to wait before upgrading.</param>
        public async virtual Task UpgradeAsync(int upgradeTimeInSeconds)
        {
            // Simulate the time passing for the upgrade
            await Task.Delay(upgradeTimeInSeconds * 1000);

            // Perform the upgrade
            Level++;
            HealthPoints += 100; // Example: Increase health points on upgrade
        }
    }

    internal class Defense(
        string buildingId,
        string villageId,
        string name,
        int level,
        int healthPoints,
        double damagePerSecond,
        int targetsNumber,
        int attackRange
    ) : BaseBuilding(buildingId, villageId, name, level, healthPoints, BuildingType.Defense)
    {
        public double DamagePerSecond { get; set; } = damagePerSecond;
        public int TargetsNumber { get; set; } = targetsNumber;
        public int AttackRange { get; set; } = attackRange;

        public async override Task UpgradeAsync(int upgradeTimeInSeconds)
        {
            await Task.Delay(upgradeTimeInSeconds * 1000);
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

    internal class ResourceExtractor(
        string buildingId,
        string villageId,
        string name,
        int level,
        int healthPoints,
        ResourceType type,
        int productionRate
    ) : BaseBuilding(buildingId, villageId, name, level, healthPoints, BuildingType.Resource)
    {
        public ResourceType ResourceType { get; } = type;
        public int ProductionRate { get; set; } = productionRate;
        public async override Task UpgradeAsync(int upgradeTimeInSeconds)
        {
            await Task.Delay(upgradeTimeInSeconds * 1000);
            Level++;
            HealthPoints += 100;
            ProductionRate += 100;
        }
    }

    internal class SpecialBuilding(
        string buildingId,
        string villageId,
        string name,
        int level,
        int healthPoints,
        string description,
        SpecialBuildingRole role
    ) : BaseBuilding(buildingId, villageId, name, level, healthPoints, BuildingType.Special)
    {
        public string Description { get; } = description;
        public SpecialBuildingRole Role { get; } = role;
    }
}
