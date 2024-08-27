using DatabaseProject.context;
using DatabaseProject.database;

namespace DatabaseProject.daos
{
    public static class WarDao
    {
        public static void CreateWar(Guid warId, Guid clan1, Guid clan2)
        {
            using var ctx = new ClashOfClansContext();
            var war = new Guerra
            {
                IdGuerra = warId,
                InCorso = "1"
            };
            ctx.Guerre.Add(war);
            var combat1 = new Combattimento
            {
                IdClan = clan1,
                IdGuerra = war.IdGuerra,
                StelleOttenute = 0,
                AttacchiEffettuati = 0,
                TempoMedioAttacco = 0.0f,
                Vincitore = "0"
            };
            var combat2 = new Combattimento
            {
                IdClan = clan2,
                IdGuerra = war.IdGuerra,
                StelleOttenute = 0,
                AttacchiEffettuati = 0,
                TempoMedioAttacco = 0.0f,
                Vincitore = "0"
            };
            ctx.Add(combat1);
            ctx.Add(combat2);
            ctx.SaveChanges();
        }

        public static List<Combattimento> GetCombatsFromWar(Guid warId)
        {
            using var context = new ClashOfClansContext();
            return [.. context.Combattimenti.Where(combat => combat.IdGuerra == warId)];
        }

        /// <summary>
        /// WinnerClan is nullable because wars may end in a draw.
        /// </summary>
        /// <param name="warId"></param>
        /// <param name="winnerClan"></param>
        public static void EndWar(Guid warId, Guid? winnerClan)
        {
            using var ctx = new ClashOfClansContext();
            var war = ctx.Guerre.Find(warId);
            war!.InCorso = "0";
            if (winnerClan != null)
            {
                ctx.Combattimenti
                .First(combat => combat.IdGuerra == warId && combat.IdClan == winnerClan)!
                .Vincitore = "1";
            }
            ctx.SaveChanges();
        }

        public static List<Clan> GetContenders(Guid warId)
        {
            using var ctx = new ClashOfClansContext();
            return ctx.Combattimenti
                .Where(combat => combat.IdGuerra == warId)
                .Select(combat => combat.IdClanNavigation)
                .Distinct()
                .Take(2)
                .ToList();
        }

        public static ISet<Attacco> GetClanAttacks(Guid warId, Guid clanId)
        {
            using var ctx = new ClashOfClansContext();
            var attacks = from war in ctx.Guerre
                          join attacksInWar in ctx.AttacchiEGuerre on war.IdGuerra equals attacksInWar.IdGuerra
                          join attack in ctx.Attacchi on attacksInWar.IdAttacco equals attack.IdAttacco // take all the attacks in this war
                          join combat in ctx.Combattimenti on war.IdGuerra equals combat.IdGuerra // take all the combats in this war
                          where war.IdGuerra == warId && combat.IdClan == clanId // filter this war and this clan
                          select attack; // take all the attacks
            return attacks.ToHashSet();
        }

        public static List<Guerra> GetAllWars()
        {
            using var ctx = new ClashOfClansContext();
            return [.. ctx.Guerre];
        }

        /**
         * The war dao needs to:
         * - add the attack in the attack table
         * - update the combat table (obtained stars, number of performed attacks of the attacker clan, average attack time).
         * - update the village with obtained trophies and stars, and also the strength
         */
        public static void CreateWarAttack(
            Attacco attack, 
            Account attacker,
            float newAttackerStrength,
            Account defender, 
            Clan attackerClan,
            Clan defenderClan,
            float averageAttacksTimeOfAttackerClan, 
            Guid warId)
        {
            using (var context = new ClashOfClansContext())
            {
                // Updating attacker clan combat
                Combattimento combat = context.Combattimenti.Find(warId, attackerClan.IdClan)!;
                combat.AttacchiEffettuati++;
                combat.StelleOttenute += attack.StelleOttenute;
                combat.TempoMedioAttacco = averageAttacksTimeOfAttackerClan;
                
                // Updating account villages
                Villaggio attackerVillage = context.Villaggi.Find(context.VillaggiAccount.Find(attacker.IdAccount)!.IdVillaggio)!;
                attackerVillage.NumeroStelleGuerra += attack.StelleOttenute;
                int possibleNewTrophiesAttacker = attackerVillage.NumeroTrofei + attack.TrofeiAttaccante;
                attackerVillage.NumeroTrofei = possibleNewTrophiesAttacker >= 0 ? possibleNewTrophiesAttacker : 0;
                attackerVillage.Forza = newAttackerStrength;

                Villaggio defenderVillage = context.Villaggi.Find(context.VillaggiAccount.Find(defender.IdAccount)!.IdVillaggio)!;
                int possibleNewTrophiesDefender = defenderVillage.NumeroTrofei + attack.TrofeiDifensore;
                defenderVillage.NumeroTrofei = possibleNewTrophiesDefender >= 0 ? possibleNewTrophiesDefender : 0;

                // Updating clans
                Clan attackerClanInContext = context.Clan.Find(attackerClan.IdClan)!;
                attackerClanInContext.StelleGuerraTotali += attack.StelleOttenute;
                int newAttackerClanTrophies = 
                    (
                        from village in context.Villaggi
                        where
                        (
                            from accountVillage in context.VillaggiAccount
                            where
                            (
                                from account in context.Account
                                join participation in context.PartecipazioniClan
                                on account.IdAccount equals participation.IdAccount
                                where participation.DataFine == null && participation.IdClan == attackerClan.IdClan
                                select account.IdAccount
                            ).Contains(accountVillage.IdAccount)
                            select accountVillage.IdVillaggio
                        ).Contains(village.IdVillaggio)
                        select village.NumeroTrofei
                    )
                    .Sum();
                attackerClanInContext.TrofeiTotali = newAttackerClanTrophies;
                Clan defenderClanInContext = context.Clan.Find(defenderClan.IdClan)!;
                int newDefenderClanTrophies =
                    (
                        from village in context.Villaggi
                        where
                        (
                            from accountVillage in context.VillaggiAccount
                            where
                            (
                                from account in context.Account
                                join participation in context.PartecipazioniClan
                                on account.IdAccount equals participation.IdAccount
                                where participation.DataFine == null && participation.IdClan == defenderClan.IdClan
                                select account.IdAccount
                            ).Contains(accountVillage.IdAccount)
                            select accountVillage.IdVillaggio
                        ).Contains(village.IdVillaggio)
                        select village.NumeroTrofei
                    )
                    .Sum();
                defenderClanInContext.TrofeiTotali = newDefenderClanTrophies >= 0 ? newDefenderClanTrophies : 0;

                // Updating attacks
                context.Attacchi.Add(attack);

                // Updating AttacksInWar
                context.AttacchiEGuerre.Add(new AttaccoEGuerra
                {
                    IdAttacco = attack.IdAttacco,
                    IdGuerra = warId
                });

                // Creating attackerAccounts and defenderAccounts entities (representing an attack and a defense relative to this attack)
                context.AccountAttaccanti.Add(new AccountAttaccante
                {
                    IdAccount = attacker.IdAccount,
                    IdAttacco = attack.IdAttacco
                });
                context.AccountDifensori.Add(new AccountDifensore
                {
                    IdAccount = defender.IdAccount,
                    IdAttacco = attack.IdAttacco
                });

                context.SaveChanges();
            }
        }
    }
}
