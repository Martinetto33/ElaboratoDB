using DatabaseProject.database;

namespace DatabaseProject.daos
{
    public static partial class DatabaseEntitiesFactory
    {
        public static Truppa CreateBarbarian(Guid villageGuid)
        {
            return new Truppa()
            {
                IdVillaggio = villageGuid,
                Id = Guid.NewGuid(),
                Nome = "Barbaro",
                Livello = 1,
                PuntiVita = 45,
                DanniInflitti = 8,
                Descrizione = "Un barbaro forte e coraggioso."
            };
        }

        public static Truppa CreateArcher(Guid villageGuid)
        {
            return new Truppa()
            {
                IdVillaggio = villageGuid,
                Id = Guid.NewGuid(),
                Nome = "Arciere",
                Livello = 1,
                PuntiVita = 20,
                DanniInflitti = 5,
                Descrizione = "Un arciere veloce e preciso."
            };
        }

        public static Truppa CreateGiant(Guid villageGuid)
        {
            return new Truppa()
            {
                IdVillaggio = villageGuid,
                Id = Guid.NewGuid(),
                Nome = "Gigante",
                Livello = 1,
                PuntiVita = 300,
                DanniInflitti = 15,
                Descrizione = "Un gigante lento ma resistente."
            };
        }

        public static Truppa CreateWizard(Guid villageGuid)
        {
            return new Truppa()
            {
                IdVillaggio = villageGuid,
                Id = Guid.NewGuid(),
                Nome = "Mago",
                Livello = 1,
                PuntiVita = 50,
                DanniInflitti = 20,
                Descrizione = "Un mago potente e letale."
            };
        }

        public static Truppa CreateHealer(Guid villageGuid)
        {
            return new Truppa()
            {
                IdVillaggio = villageGuid,
                Id = Guid.NewGuid(),
                Nome = "Guaritore",
                Livello = 1,
                PuntiVita = 50,
                DanniInflitti = 0,
                Descrizione = "Un guaritore che cura le truppe."
            };
        }

        public static Truppa CreateDragon(Guid villageGuid)
        {
            return new Truppa()
            {
                IdVillaggio = villageGuid,
                Id = Guid.NewGuid(),
                Nome = "Drago",
                Livello = 1,
                PuntiVita = 200,
                DanniInflitti = 50,
                Descrizione = "Un drago che sputa fuoco."
            };
        }

        public static Truppa CreatePekka(Guid villageGuid)
        {
            return new Truppa()
            {
                IdVillaggio = villageGuid,
                Id = Guid.NewGuid(),
                Nome = "Pekka",
                Livello = 1,
                PuntiVita = 300,
                DanniInflitti = 25,
                Descrizione = "Una P.E.K.K.A. potente e resistente."
            };
        }

        public static Truppa CreateWallbreaker(Guid villageGuid)
        {
            return new Truppa()
            {
                IdVillaggio = villageGuid,
                Id = Guid.NewGuid(),
                Nome = "Spaccamuro",
                Livello = 1,
                PuntiVita = 20,
                DanniInflitti = 40,
                Descrizione = "Uno scheletrino con una bomba che fa saltare le mura."
            };
        }

        public static Truppa CreateGoblin(Guid villageGuid)
        {
            return new Truppa()
            {
                IdVillaggio = villageGuid,
                Id = Guid.NewGuid(),
                Nome = "Goblin",
                Livello = 1,
                PuntiVita = 30,
                DanniInflitti = 10,
                Descrizione = "Un goblin furbo e assetato di ricchezze."
            };
        }

        public static Truppa CreateBalloon(Guid villageGuid)
        {
            return new Truppa()
            {
                IdVillaggio = villageGuid,
                Id = Guid.NewGuid(),
                Nome = "Mongolfiera",
                Livello = 1,
                PuntiVita = 150,
                DanniInflitti = 50,
                Descrizione = "Una mongolfiera che sgancia bombe."
            };
        }
    }
}
