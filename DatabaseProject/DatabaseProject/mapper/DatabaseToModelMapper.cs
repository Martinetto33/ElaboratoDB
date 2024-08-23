using DatabaseProject.daos;
using DatabaseProject.database;
using DatabaseProject.model.code;

namespace DatabaseProject.mapper
{
    /// <summary>
    /// Methods called "Map" transform a database object into a model object.
    /// Methods called "Unmap" transform a model object into a database object.
    /// </summary>
    public static class DatabaseToModelMapper
    {
        // MAPPERS
        public static Player Map(Giocatore giocatore)
        {
            var player = new Player(giocatore.IdGiocatore.ToString(), giocatore.Nome, giocatore.Cognome);
            foreach (var account in giocatore.Accounts)
            {
                player.Accounts.Add(Map(account));
            }
            return player;
        }

        public static model.code.Account Map(database.Account account)
        {
            return new model.code.Account(account.IdAccount.ToString(), account.Username, account.Email)
            {
                Village = Map(account.IdVillaggioNavigation)
            };
        }

        public static Village Map(Villaggio villaggio)
        {
            HashSet<SpecialBuilding> specialBuildings = [];
            HashSet<ResourceExtractor> resourceExtractors = [];
            HashSet<Defense> defenses = [];
            HashSet<Builder> builders = [];
            HashSet<Troop> troops = [];
            foreach (var builder in villaggio.Costruttori) builders.Add(Map(builder));
            foreach (var building in villaggio.Edifici)
            {
                BuildingType type = Enum.Parse<BuildingType>(building.Tipo);
                switch (type)
                {
                    case BuildingType.Special:
                        specialBuildings.Add(MapSpecialBuilding(building));
                        break;
                    case BuildingType.Resource:
                        resourceExtractors.Add(MapResourceExtractor(building));
                        break;
                    case BuildingType.Defense:
                        defenses.Add(MapDefense(building));
                        break;
                    default:
                        throw new ArgumentException($"Invalid building type: {type}.");
                }
            }
            foreach (var troop in villaggio.Truppe) troops.Add(Map(troop));
            return new Village
                (
                    villaggio.IdVillaggio.ToString(),
                    villaggio.LivelloEsperienza,
                    villaggio.NumeroTrofei,
                    villaggio.NumeroStelleGuerra,
                    specialBuildings,
                    resourceExtractors,
                    defenses,
                    builders,
                    troops
                );
        }
        public static model.code.Clan Map(database.Clan clan)
        {
            Dictionary<string, ClanRole> members = [];
            foreach (var member in clan.PartecipazioniClan.Where(participation => participation.DataFine is null))
            {
                members.Add(member.IdAccount.ToString(), Enum.Parse<ClanRole>(member.Ruolo));
            }
            return new model.code.Clan(clan.IdClan.ToString(), clan.Nome, members, clan.TrofeiTotali, clan.StelleGuerraTotali);
        }

        public static Attack Map(Attacco attack)
        {
            AttackTrophies attackTrophies = AttackDao.GetTrophiesFromAttack(attack);
            return new Attack(attack.IdAttacco.ToString(), attackTrophies.AttackerTrophies, attackTrophies.DefenderTrophies)
            {
                TimeTakenMS = (long)attack.TempoImpiegato,
                ObtainedPercentage = attack.PercentualeDistruzione,
                ObtainedStars = attack.StelleOttenute
            };
        }

        public static War Map(Guerra war)
        {
            var registry = new Dictionary<model.code.Clan, ISet<Attack>>();
            List<database.Clan> contenders = WarDao.GetContenders(war.IdGuerra);
            Dictionary<database.Clan, ISet<Attacco>> databaseRegistry = [];
            contenders.ForEach(clan =>
            {
                databaseRegistry.Add(clan, WarDao.GetClanAttacks(war.IdGuerra, clan.IdClan));
            });
            foreach (var item in databaseRegistry)
            {
                // Select is the equivalent for map in Java
                registry.Add(Map(item.Key), item.Value.Select(attack => Map(attack)).ToHashSet());
            }
            return new War(war.IdGuerra.ToString(), registry, war.InCorso == "T");
        }
        public static Builder Map(Costruttore costruttore) => new(costruttore.IdCostruttore);
        public static Troop Map(Truppa troop) => new(troop.Nome, troop.Livello, troop.PuntiVita, troop.DanniInflitti, troop.Descrizione);
        public static SpecialBuilding MapSpecialBuilding(Edificio edificio)
        {
            if (edificio.Occupato == null)
            {
                // Then it's not the laboratory
                return new SpecialBuilding
                    (
                        edificio.IdEdificio,
                        edificio.Nome,
                        edificio.Livello,
                        edificio.PuntiVita,
                        edificio.DescrizioneFunzione!,
                        Enum.Parse<SpecialBuildingRole>(edificio.Ruolo!)
                    );
            }
            else
            {
                return new Laboratory
                    (
                        edificio.IdEdificio,
                        edificio.Nome,
                        edificio.Livello,
                        edificio.PuntiVita,
                        edificio.DescrizioneFunzione!
                    )
                {
                    IsBusy = edificio.Occupato == "T"
                };
            }
        }
        public static ResourceExtractor MapResourceExtractor(Edificio edificio) =>
            new
            (
                edificio.IdEdificio,
                edificio.Nome,
                edificio.Livello,
                edificio.PuntiVita,
                Enum.Parse<ResourceType>(edificio.TipoRisorsa!),
                edificio.ProduzioneOraria!.Value
            );
        public static Defense MapDefense(Edificio edificio) =>
            new
            (
                edificio.IdEdificio,
                edificio.Nome,
                edificio.Livello,
                edificio.PuntiVita,
                edificio.DanniAlSecondo!.Value,
                edificio.NumeroBersagli!.Value,
                edificio.RaggioAzione!.Value
            );

        // UNMAPPERS

    }
}
