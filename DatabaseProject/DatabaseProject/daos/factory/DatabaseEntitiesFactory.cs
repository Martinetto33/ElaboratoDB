using DatabaseProject.config;
using DatabaseProject.database;

namespace DatabaseProject.daos
{
    /// <summary>
    /// Methods in this class should not update the database: that's the daos' job.
    /// This class builds the core entities; for specific entities such as buildings
    /// or troops, see the other partial classes.
    /// </summary>
    public static partial class DatabaseEntitiesFactory
    {
        /// <summary>
        /// Create a new village for the given account.
        /// This method doesn't automatically add the village id to the provided account!
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static Villaggio CreateVillage(Account account)
        {
            Guid villageGuid = Guid.NewGuid();
            var builders = new List<Costruttore>();
            for (int i = 0; i < Configuration.BUILDERS_NUMBER; i++)
            {
                builders.Add(CreateBuilder(villageGuid, i));
            }
            return new Villaggio
            {
                IdVillaggio = villageGuid,
                VillaggioAccount = CreateAccountVillage(villageGuid, account.IdAccount),
                Costruttori = builders,
                EdificiInVillaggio = CreateBuildings(villageGuid),
                TruppeInVillaggio = CreateTroops(villageGuid),
                Forza = 0,
                LivelloEsperienza = 0,
                NumeroTrofei = 0,
                NumeroStelleGuerra = 0
            };
        }

        public static VillaggioAccount CreateAccountVillage(Guid villageGuid, Guid accountGuid)
        {
            return new VillaggioAccount
            {
                IdVillaggio = villageGuid,
                IdAccount = accountGuid
            };
        }

            public static Costruttore CreateBuilder(Guid villageGuid, int builderId)
        {
            return new Costruttore
            {
                IdCostruttore = builderId,
                IdVillaggio = villageGuid
            };
        }

        public static List<EdificioInVillaggio> CreateBuildings(Guid villageGuid)
        {
            List<EdificioInVillaggio> buildings = [];
            int buildingId = 0;
            buildings.Add(CreateTownHall(villageGuid, buildingId++));
            buildings.Add(CreateLaboratory(villageGuid, buildingId++));
            buildings.Add(CreateArmyCamp(villageGuid, buildingId++));
            buildings.Add(CreateClanCastle(villageGuid, buildingId++));
            for (int i = 0; i < Configuration.RESOURCE_BUILDINGS_NUMBER; i++)
            {
                buildings.Add(CreateGoldMine(villageGuid, buildingId++));
                buildings.Add(CreateElixirCollector(villageGuid, buildingId++));
                buildings.Add(CreateDarkElixirDrill(villageGuid, buildingId++));
            }
            for (int i = 0; i < Configuration.ARCHER_TOWERS_NUMBER; i++)
            {
                buildings.Add(CreateArcherTower(villageGuid, buildingId++));
            }
            for (int i = 0; i < Configuration.CANNONS_NUMBER; i++)
            {
                buildings.Add(CreateCannon(villageGuid, buildingId++));
            }
            for (int i = 0; i < Configuration.XBOWS_NUMBER; i++)
            {
                buildings.Add(CreateXBow(villageGuid, buildingId++));
            }
            for (int i = 0; i < Configuration.INFERNO_TOWERS_NUMBER; i++)
            {
                buildings.Add(CreateInfernoTower(villageGuid, buildingId++));
            }
            for (int i = 0; i < Configuration.WIZARD_TOWERS_NUMBER; i++)
            {
                buildings.Add(CreateWizardTower(villageGuid, buildingId++));
            }
            for (int i = 0; i < Configuration.AIR_DEFENSES_NUMBER; i++)
            {
                buildings.Add(CreateAirDefense(villageGuid, buildingId++));
            }
            return buildings;
        }

        public static List<TruppaInVillaggio> CreateTroops(Guid villageGuid)
        {
            var troopNames = new List<string> { "Barbaro", 
                "Arciere", "Gigante", "Goblin", "Spaccamuro", 
                "Stregone", "Mongolfiera", "Guaritore", "Drago", "Pekka" };
            return troopNames.Select(troopName => CreateTroop(villageGuid, troopName)).ToList();
        }
    }
}
