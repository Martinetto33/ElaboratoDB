using DatabaseProject.common;
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

        /// <summary>
        /// Accounts for this player may not have their villages set, if the village
        /// was not present in the database.
        /// </summary>
        /// <param name="giocatore"></param>
        /// <returns></returns>
        public static Player Map(Giocatore giocatore)
        {
            var player = new Player(giocatore.IdGiocatore.ToString(), giocatore.Nome, giocatore.Cognome);
            giocatore.Accounts
                .Select(account => Map(account))
                .ToList()
                .ForEach(mappedAccount => player.Accounts.Add(mappedAccount));
            return player;
        }

        public static model.code.Account Map(database.Account account)
        {
            var village = VillageDao.GetVillageFromAccount(account);
            if (village is null)
                return new model.code.Account(account.Username, account.Email, account.IdAccount.ToString());
            return new model.code.Account(account.Username, account.Email, account.IdAccount.ToString())
            {
                Village = Map(village)
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
            foreach (var building in villaggio.EdificiInVillaggio)
            {
                Enums.BuildingType type = Enum.Parse<Enums.BuildingType>(building.Categoria);
                switch (type)
                {
                    case Enums.BuildingType.Special:
                        specialBuildings.Add(MapSpecialBuilding(building));
                        break;
                    case Enums.BuildingType.Resource:
                        resourceExtractors.Add(MapResourceExtractor(building));
                        break;
                    case Enums.BuildingType.Defense:
                        defenses.Add(MapDefense(building));
                        break;
                    default:
                        throw new ArgumentException($"Invalid building type: {type}.");
                }
            }
            foreach (var troop in villaggio.TruppeInVillaggio) troops.Add(Map(troop));
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
            Dictionary<string, Enums.ClanRole> members = [];
            foreach (var member in clan.PartecipazioniClan.Where(participation => participation.DataFine is null))
            {
                members.Add(member.IdAccount.ToString(), Enum.Parse<Enums.ClanRole>(member.Ruolo));
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
            return new War(war.IdGuerra.ToString(), registry, war.InCorso == "0");
        }
        public static Builder Map(Costruttore costruttore) => new(costruttore.IdCostruttore);
        public static Troop Map(TruppaInVillaggio troop)
        {
            var troopStats = StatisticsDao.GetStatisticsForTroopFromLevelAndName(troop.Livello, troop.Nome);
            var description = TroopNameDao.GetTroopDescriptionFromName(troop.Nome);
            return new Troop
                (
                    troop.Nome,
                    troop.Livello,
                    troopStats.PuntiVita,
                    troopStats.DanniInflitti,
                    description
                );
        }
        public static SpecialBuilding MapSpecialBuilding(EdificioInVillaggio edificio)
        {
            if (Enum.Parse<Enums.SpecialBuildingRole>(edificio.RuoloEdificioSpeciale!) != Enums.SpecialBuildingRole.Laboratory)
            {
                // Then it's not the laboratory
                var buildingHP = StatisticsDao.GetStatisticsForBuildingFromLevelAndName(edificio.LivelloMiglioramento, edificio.Nome);
                return new SpecialBuilding
                    (
                        edificio.IdEdificio,
                        edificio.Nome,
                        edificio.LivelloMiglioramento,
                        buildingHP.PuntiVita,
                        edificio.DescrizioneFunzione!,
                        Enum.Parse<Enums.SpecialBuildingRole>(edificio.RuoloEdificioSpeciale!)
                    );
            }
            else
            {
                var buildingHP = StatisticsDao.GetStatisticsForBuildingFromLevelAndName(edificio.LivelloMiglioramento, edificio.Nome);
                return new Laboratory
                    (
                        edificio.IdEdificio,
                        edificio.Nome,
                        edificio.LivelloMiglioramento,
                        buildingHP.PuntiVita,
                        edificio.DescrizioneFunzione!
                    )
                {
                    IsBusy = false
                };
            }
        }
        public static ResourceExtractor MapResourceExtractor(EdificioInVillaggio edificio)
        {
            var buildingHP = StatisticsDao.GetStatisticsForBuildingFromLevelAndName(edificio.LivelloMiglioramento, edificio.Nome);
            return new
            (
                edificio.IdEdificio,
                edificio.Nome,
                edificio.LivelloMiglioramento,
                buildingHP.PuntiVita,
                Enum.Parse<Enums.ResourceType>(edificio.TipoRisorsa!),
                edificio.ProduzioneOraria!.Value
            );
        }

        public static Defense MapDefense(EdificioInVillaggio edificio)
        {
            var buildingHp = StatisticsDao.GetStatisticsForBuildingFromLevelAndName(edificio.LivelloMiglioramento, edificio.Nome);
            return new
            (
                edificio.IdEdificio,
                edificio.Nome,
                edificio.LivelloMiglioramento,
                buildingHp.PuntiVita,
                edificio.DanniAlSecondo!.Value,
                edificio.NumeroBersagli!.Value,
                edificio.RaggioAzione!.Value
            );
        }

        // UNMAPPERS

        public static Giocatore Unmap(Player player)
        {
            return new Giocatore()
            {
                IdGiocatore = Guid.Parse(player.Id),
                Nome = player.Name,
                Cognome = player.Surname
            };
        }

        /// <summary>
        /// Warning: no reference to the <see cref="Giocatore"/> owning
        /// this account!
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static database.Account Unmap(model.code.Account account)
        {
            return new database.Account()
            {
                IdAccount = Guid.Parse(account.Id),
                Username = account.Username,
                Email = account.Email
            };
        }

        public static database.Account Unmap(model.code.Account account, Player owner)
        {
            return new database.Account()
            {
                IdAccount = Guid.Parse(account.Id),
                IdGiocatore = Guid.Parse(owner.Id),
                Username = account.Username,
                Email = account.Email
            };
        }

        /// <summary>
        /// Warning: there's no reference to the account in the village!
        /// You need to find the <see cref="VillaggioAccount"/> entity
        /// linked to the id of this village to find the reference to the correct
        /// account.
        /// </summary>
        /// <param name="village"></param>
        /// <returns></returns>
        public static Villaggio Unmap(Village village)
        {
            return new Villaggio()
            {
                IdVillaggio = Guid.Parse(village.VillageId),
                LivelloEsperienza = village.ExperienceLevel,
                NumeroTrofei = village.Trophies,
                NumeroStelleGuerra = village.WarStars,
                Forza = (float)village.Strength,
                Costruttori = village.Builders.Select(builder => Unmap(builder)).ToList(),
                EdificiInVillaggio = village.SpecialBuildings
                    .Select(specialBuilding => Unmap(specialBuilding, village))
                    .Concat(village.Extractors.Select(extractor => Unmap(extractor, village)))
                    .Concat(village.Defenses.Select(defense => Unmap(defense, village)))
                    .ToList(),
                TruppeInVillaggio = village.Troops.Select(troop => Unmap(troop, village)).ToList()
            };
        }

        public static database.Clan Unmap(model.code.Clan clan)
        {
            return new database.Clan()
            {
                IdClan = Guid.Parse(clan.ClanId),
                Nome = clan.Name,
                TrofeiTotali = clan.TotalTrophies,
                StelleGuerraTotali = clan.TotalStarsWon,
                NumeroMembri = clan.Members.Count
            };
        }

        public static Guerra Unmap(War war)
        {
            return new Guerra()
            {
                IdGuerra = Guid.Parse(war.WarId),
                InCorso = war.IsInProgress ? "1" : "0"
            };
        }

        public static Attacco Unmap(Attack attack)
        {
            return new Attacco()
            {
                IdAttacco = Guid.Parse(attack.Id),
                PercentualeDistruzione = attack.ObtainedPercentage!.Value,
                StelleOttenute = attack.ObtainedStars!.Value,
                TempoImpiegato = attack.TimeTakenMS!.Value,
                TrofeiAttaccante = attack.GetAttackerAndDefenderTrophies().AttackerTrophies,
                TrofeiDifensore = attack.GetAttackerAndDefenderTrophies().DefenderTrophies
            };
        }

        /// <summary>
        /// Warning: no reference to village contained!
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static Costruttore Unmap(Builder builder) => new() { IdCostruttore = builder.BuilderId };
        public static Costruttore Unmap(Builder builder, Village builderVillage) =>
            new() { IdCostruttore = builder.BuilderId, IdVillaggio = Guid.Parse(builderVillage.VillageId) };


        /// <summary>
        /// Warning: this troop does not contain a reference to its village!
        /// </summary>
        /// <param name="troop"></param>
        /// <returns></returns>
        public static TruppaInVillaggio Unmap(Troop troop)
        {
            return new TruppaInVillaggio()
            {
                Livello = troop.Level,
                Nome = troop.Name
            };
        }

        public static TruppaInVillaggio Unmap(Troop troop, Village villageContainingTroop)
        {
            return new TruppaInVillaggio()
            {
                Livello = troop.Level,
                Nome = troop.Name,
                IdVillaggio = Guid.Parse(villageContainingTroop.VillageId)
            };
        }

        public static EdificioInVillaggio Unmap(BaseBuilding building, Village village)
        {
            return building.BuildingType switch
            {
                Enums.BuildingType.Special => Unmap((SpecialBuilding)building, village),
                Enums.BuildingType.Resource => Unmap((ResourceExtractor)building, village),
                Enums.BuildingType.Defense => Unmap((Defense)building, village),
                _ => throw new ArgumentException($"Invalid building type: {building.BuildingType}."),
            };
        }

        /// <summary>
        /// Warning: this method can't set the village id, since in the model
        /// buildings do not have a reference to the village containing them!
        /// </summary>
        /// <param name="extractor"></param>
        /// <returns></returns>
        public static EdificioInVillaggio Unmap(ResourceExtractor extractor)
        {
            return new EdificioInVillaggio()
            {
                IdEdificio = extractor.BuildingId,
                Categoria = extractor.BuildingType.ToString(),
                TipoRisorsa = extractor.ResourceType.ToString(),
                ProduzioneOraria = extractor.ProductionRate,
                Nome = extractor.Name,
                LivelloMiglioramento = extractor.Level
            };
        }

        public static EdificioInVillaggio Unmap(ResourceExtractor extractor, Village villageContainingExtractor)
        {
            return new EdificioInVillaggio()
            {
                IdEdificio = extractor.BuildingId,
                IdVillaggio = Guid.Parse(villageContainingExtractor.VillageId),
                Categoria = extractor.BuildingType.ToString(),
                TipoRisorsa = extractor.ResourceType.ToString(),
                ProduzioneOraria = extractor.ProductionRate,
                Nome = extractor.Name,
                LivelloMiglioramento = extractor.Level
            };
        }

        /// <summary>
        /// Warning: this method can't set the village id, since in the model
        /// buildings do not have a reference to the village containing them!
        /// </summary>
        /// <param name="specialBuilding"></param>
        /// <returns></returns>
        public static EdificioInVillaggio Unmap(SpecialBuilding specialBuilding)
        {
            return new EdificioInVillaggio()
            {
                IdEdificio = specialBuilding.BuildingId,
                Categoria = specialBuilding.BuildingType.ToString(),
                Nome = specialBuilding.Name,
                LivelloMiglioramento = specialBuilding.Level,
                DescrizioneFunzione = specialBuilding.Description,
                RuoloEdificioSpeciale = specialBuilding.Role.ToString()
            };
        }
        public static EdificioInVillaggio Unmap(SpecialBuilding specialBuilding, Village villageContainingBuilding)
        {
            return new EdificioInVillaggio()
            {
                IdEdificio = specialBuilding.BuildingId,
                IdVillaggio = Guid.Parse(villageContainingBuilding.VillageId),
                Categoria = specialBuilding.BuildingType.ToString(),
                Nome = specialBuilding.Name,
                LivelloMiglioramento = specialBuilding.Level,
                DescrizioneFunzione = specialBuilding.Description,
                RuoloEdificioSpeciale = specialBuilding.Role.ToString()
            };
        }


        /// <summary>
        /// Warning: this method can't set the village id, since in the model
        /// buildings do not have a reference to the village containing them!
        /// </summary>
        /// <param name="defense"></param>
        /// <returns></returns>
        public static EdificioInVillaggio Unmap(Defense defense)
        {
            return new EdificioInVillaggio()
            {
                IdEdificio = defense.BuildingId,
                Categoria = defense.BuildingType.ToString(),
                DanniAlSecondo = (int)defense.DamagePerSecond,
                NumeroBersagli = defense.TargetsNumber,
                RaggioAzione = defense.AttackRange,
                Nome = defense.Name,
                LivelloMiglioramento = defense.Level
            };
        }

        public static EdificioInVillaggio Unmap(Defense defense, Village villageContainingDefense)
        {
            return new EdificioInVillaggio()
            {
                IdEdificio = defense.BuildingId,
                IdVillaggio = Guid.Parse(villageContainingDefense.VillageId),
                Categoria = defense.BuildingType.ToString(),
                DanniAlSecondo = (int)defense.DamagePerSecond,
                NumeroBersagli = defense.TargetsNumber,
                RaggioAzione = defense.AttackRange,
                Nome = defense.Name,
                LivelloMiglioramento = defense.Level
            };
        }
    }
}
