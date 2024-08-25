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
                """.Replace("\n", " ").Trim(),
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
                Categoria = Enums.BuildingType.Special.ToString(),
                DescrizioneFunzione = """
                Il laboratorio è dove puoi migliorare le tue truppe. 
                Migliorando il laboratorio, sbloccherai nuove truppe e potenziamenti.
                """.Replace("\n", " ").Trim(),
                RuoloEdificioSpeciale = Enums.SpecialBuildingRole.Laboratory.ToString(),
            };
        }

        public static EdificioInVillaggio CreateArmyCamp(Guid villageGuid, int buildingId)
        {
            return new EdificioInVillaggio
            {
                IdEdificio = buildingId,
                IdVillaggio = villageGuid,
                Nome = "Accampamento",
                LivelloMiglioramento = 1,
                Categoria = Enums.BuildingType.Special.ToString(),
                DescrizioneFunzione = """
                L'accampamento è dove le tue truppe si preparano per la battaglia. 
                """.Replace("\n", " ").Trim(),
                RuoloEdificioSpeciale = Enums.SpecialBuildingRole.ArmyCamp.ToString()
            };
        }

        public static EdificioInVillaggio CreateClanCastle(Guid villageGuid, int buildingId)
        {
            return new EdificioInVillaggio
            {
                IdEdificio = buildingId,
                IdVillaggio = villageGuid,
                Nome = "Castello del clan",
                LivelloMiglioramento = 1,
                Categoria = Enums.BuildingType.Special.ToString(),
                DescrizioneFunzione = "Il castello del clan porta i vessilli del tuo clan." +
                "È il simbolo della tua partecipazione ad un gruppo di " +
                "grandiosi guerrieri. Miglioralo per ottenere benefici " +
                "per il tuo clan!".Replace("\n", " ").Trim(),
                RuoloEdificioSpeciale = Enums.SpecialBuildingRole.ClanCastle.ToString()
            };
        }

        public static EdificioInVillaggio CreateArcherTower(Guid villageGuid, int buildingId)
        {
            return new EdificioInVillaggio()
            {
                IdVillaggio = villageGuid,
                IdEdificio = buildingId,
                Nome = "Torre dell'arciere",
                LivelloMiglioramento = 1,
                Categoria = Enums.BuildingType.Defense.ToString(),
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
                LivelloMiglioramento = 1,
                Categoria = Enums.BuildingType.Defense.ToString(),
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
                LivelloMiglioramento = 1,
                Categoria = Enums.BuildingType.Defense.ToString(),
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
                LivelloMiglioramento = 1,
                Categoria = Enums.BuildingType.Defense.ToString(),
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
                LivelloMiglioramento = 1,
                Categoria = Enums.BuildingType.Defense.ToString(),
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
                LivelloMiglioramento = 1,
                Categoria = Enums.BuildingType.Defense.ToString(),
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
                LivelloMiglioramento = 1,
                Categoria = Enums.BuildingType.Resource.ToString(),
                TipoRisorsa = Enums.ResourceType.Gold.ToString(),
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
                LivelloMiglioramento = 1,
                Categoria = Enums.BuildingType.Resource.ToString(),
                TipoRisorsa = Enums.ResourceType.Elixir.ToString(),
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
                LivelloMiglioramento = 1,
                Categoria = Enums.BuildingType.Resource.ToString(),
                TipoRisorsa = Enums.ResourceType.DarkElixir.ToString(),
                ProduzioneOraria = 10
            };
        }
    }
}
