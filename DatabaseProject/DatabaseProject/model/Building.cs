using DatabaseProject.config;
using DatabaseProject.database;

namespace DatabaseProject.model
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
        public async virtual Task UpgradeAsync(double upgradeTimeInSeconds)
        {
            if (this.Level < Configuration.MAX_LEVEL)
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

        public async override Task UpgradeAsync(double upgradeTimeInSeconds)
        {
            if (this.Level < Configuration.MAX_LEVEL)
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

        public static Defense FromEdificio(Edificio edificio)
        {
            return new Defense(
                edificio.IdEdificio.ToString(),
                edificio.IdVillaggio.ToString(),
                edificio.Nome,
                edificio.Livello,
                edificio.PuntiVita,
                edificio.DanniAlSecondo ?? 0,
                edificio.NumeroBersagli ?? 0,
                edificio.RaggioAzione ?? 0
            );
        }
    }

    public class ResourceExtractor(
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
        public async override Task UpgradeAsync(double upgradeTimeInSeconds)
        {
            if (this.Level < Configuration.MAX_LEVEL)
            {
                await Task.Delay((int)(upgradeTimeInSeconds * 1000));
                Level++;
                HealthPoints += 100;
                ProductionRate += 100;
            }
        }

        public static ResourceExtractor FromEdificio(Edificio edificio)
        {
            return new ResourceExtractor(
                edificio.IdEdificio.ToString(),
                edificio.IdVillaggio.ToString(),
                edificio.Nome,
                edificio.Livello,
                edificio.PuntiVita,
                Enum.Parse<ResourceType>(edificio.TipoRisorsa!),
                edificio.ProduzioneOraria ?? 0
            );
        }
    }

    public class SpecialBuilding(
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

        public static SpecialBuilding FromEdificio(Edificio edificio)
        {
            return new SpecialBuilding(
                edificio.IdEdificio.ToString(),
                edificio.IdVillaggio.ToString(),
                edificio.Nome,
                edificio.Livello,
                edificio.PuntiVita,
                edificio.DescrizioneFunzione!,
                Enum.Parse<SpecialBuildingRole>(edificio.Ruolo!)
            );
        }
    }
}
