using DatabaseProject.common;
using DatabaseProject.database;

namespace DatabaseProject.daos
{
    public static partial class DatabaseEntitiesFactory
    {
        public static EdificioInVillaggio CreateTownHall(Guid villageGuid, int buildingId)
        {
            return new EdificioInVillaggio
            {
                IdEdificio = buildingId,
                IdVillaggio = villageGuid,
                Categoria = Enums.BuildingType.Special.ToString(),
                Nome = "Municipio",
                LivelloMiglioramento = 1,
                DescrizioneFunzione = """
                Il municipio è il cuore del tuo villaggio. 
                Quando lo avrai migliorato, sbloccherai nuove strutture e difese.
                """.Trim().Replace("\n", ""),
                RuoloEdificioSpeciale = Enums.SpecialBuildingRole.TownHall.ToString()
            };
        }
        /// <summary>
        /// In this representation, upgrading the laboratory
        /// unlocks new troops.
        /// </summary>
        /// <param name="villageGuid"></param>
        /// <param name="buildingId"></param>
        /// <returns></returns>
        public static EdificioInVillaggio CreateLaboratory(Guid villageGuid, int buildingId)
        {
            return new EdificioInVillaggio
            {
                IdEdificio = buildingId,
                IdVillaggio = villageGuid,
                Nome = "Laboratorio",
                LivelloMiglioramento = 1,
                Tipo = BuildingType.Special.ToString(),
                DescrizioneFunzione = """
                Il laboratorio è dove puoi migliorare le tue truppe. 
                Migliorando il laboratorio, sbloccherai nuove truppe e potenziamenti.
                """.Trim().Replace("\n", ""),
                Ruolo = SpecialBuildingRole.Laboratory.ToString(),
                Occupato = "F" // the stupid mySQL way to represent false
            };
        }

        public static EdificioInVillaggio CreateArmyCamp(Guid villageGuid, int buildingId)
        {
            return new EdificioInVillaggio
            {
                IdEdificio = buildingId,
                IdVillaggio = villageGuid,
                Nome = "Campo d'addestramento",
                Livello = 1,
                PuntiVita = 200,
                Tipo = BuildingType.Special.ToString(),
                DescrizioneFunzione = """
                Il campo d'addestramento è dove le tue truppe si preparano per la battaglia. 
                """.Trim().Replace("\n", ""),
                Ruolo = SpecialBuildingRole.ArmyCamp.ToString()
            };
        }

        public static EdificioInVillaggio CreateClanCastle(Guid villageGuid, int buildingId)
        {
            return new EdificioInVillaggio
            {
                IdEdificio = buildingId,
                IdVillaggio = villageGuid,
                Nome = "Castello del clan",
                Livello = 1,
                PuntiVita = 800,
                Tipo = BuildingType.Special.ToString(),
                DescrizioneFunzione = """
                Il castello del clan porta i vessilli del tuo clan.
                È il simbolo della tua partecipazione ad un gruppo di
                grandiosi guerrieri. Miglioralo per ottenere benefici
                per il tuo clan!
                """.Trim().Replace("\n", ""),
                Ruolo = SpecialBuildingRole.ClanCastle.ToString()
            };
        }

        public static EdificioInVillaggio CreateArcherTower(Guid villageGuid, int buildingId)
        {
            return new EdificioInVillaggio()
            {
                IdVillaggio = villageGuid,
                IdEdificio = buildingId,
                Nome = "Torre dell'arciere",
                Livello = 1,
                PuntiVita = 360,
                Tipo = BuildingType.Defense.ToString(),
                DanniAlSecondo = 10,
                NumeroBersagli = 1,
                RaggioAzione = 10
            };
        }

        public static EdificioInVillaggio CreateCannon(Guid villageGuid, int buildingId)
        {
            return new EdificioInVillaggio()
            {
                IdVillaggio = villageGuid,
                IdEdificio = buildingId,
                Nome = "Cannone",
                Livello = 1,
                PuntiVita = 500,
                Tipo = BuildingType.Defense.ToString(),
                DanniAlSecondo = 20,
                NumeroBersagli = 1,
                RaggioAzione = 10
            };
        }

        public static EdificioInVillaggio CreateXBow(Guid villageGuid, int buildingId)
        {
            return new EdificioInVillaggio()
            {
                IdVillaggio = villageGuid,
                IdEdificio = buildingId,
                Nome = "Arco-X",
                Livello = 1,
                PuntiVita = 800,
                Tipo = BuildingType.Defense.ToString(),
                DanniAlSecondo = 50,
                NumeroBersagli = 1,
                RaggioAzione = 14
            };
        }

        public static EdificioInVillaggio CreateInfernoTower(Guid villageGuid, int buildingId)
        {
            return new EdificioInVillaggio()
            {
                IdVillaggio = villageGuid,
                IdEdificio = buildingId,
                Nome = "Torre infernale",
                Livello = 1,
                PuntiVita = 1000,
                Tipo = BuildingType.Defense.ToString(),
                DanniAlSecondo = 100,
                NumeroBersagli = 3,
                RaggioAzione = 10
            };
        }

        public static EdificioInVillaggio CreateWizardTower(Guid villageGuid, int buildingId)
        {
            return new EdificioInVillaggio()
            {
                IdVillaggio = villageGuid,
                IdEdificio = buildingId,
                Nome = "Torre dello stregone",
                Livello = 1,
                PuntiVita = 500,
                Tipo = BuildingType.Defense.ToString(),
                DanniAlSecondo = 25,
                NumeroBersagli = 10,
                RaggioAzione = 8
            };
        }

        public static EdificioInVillaggio CreateAirDefense(Guid villageGuid, int buildingId)
        {
            return new EdificioInVillaggio()
            {
                IdVillaggio = villageGuid,
                IdEdificio = buildingId,
                Nome = "Difesa aerea",
                Livello = 1,
                PuntiVita = 800,
                Tipo = BuildingType.Defense.ToString(),
                DanniAlSecondo = 50,
                NumeroBersagli = 1,
                RaggioAzione = 10
            };
        }

        public static EdificioInVillaggio CreateGoldMine(Guid villageGuid, int buildingId)
        {
            return new EdificioInVillaggio()
            {
                IdVillaggio = villageGuid,
                IdEdificio = buildingId,
                Nome = "Miniera d'oro",
                Livello = 1,
                PuntiVita = 200,
                Tipo = BuildingType.Resource.ToString(),
                TipoRisorsa = ResourceType.Gold.ToString(),
                ProduzioneOraria = 100
            };
        }

        public static EdificioInVillaggio CreateElixirCollector(Guid villageGuid, int buildingId)
        {
            return new EdificioInVillaggio()
            {
                IdVillaggio = villageGuid,
                IdEdificio = buildingId,
                Nome = "Estrattore di elisir",
                Livello = 1,
                PuntiVita = 200,
                Tipo = BuildingType.Resource.ToString(),
                TipoRisorsa = ResourceType.Elixir.ToString(),
                ProduzioneOraria = 100
            };
        }

        public static EdificioInVillaggio CreateDarkElixirDrill(Guid villageGuid, int buildingId)
        {
            return new EdificioInVillaggio()
            {
                IdVillaggio = villageGuid,
                IdEdificio = buildingId,
                Nome = "Trivella per elisir nero",
                Livello = 1,
                PuntiVita = 200,
                Tipo = BuildingType.Resource.ToString(),
                TipoRisorsa = ResourceType.DarkElixir.ToString(),
                ProduzioneOraria = 10
            };
        }
    }
}
