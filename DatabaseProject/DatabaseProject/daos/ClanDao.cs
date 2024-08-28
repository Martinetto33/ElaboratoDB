using DatabaseProject.common;
using DatabaseProject.context;
using DatabaseProject.database;
using DatabaseProject.simulator;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProject.daos
{
    public static class ClanDao
    {
        public static Clan? GetClanFromAccountId(Guid accountId)
        {
            using (var context = new ClashOfClansContext())
            {
                return (from clan in context.Clan
                        join participation in context.PartecipazioniClan
                        on clan.IdClan equals participation.IdClan
                        where participation.DataFine == null && participation.IdAccount.Equals(accountId)
                        select clan)
                        .Include(clan => clan.PartecipazioniClan)
                        .First();
            }
        }

        public static bool IsAccountInClan(Guid accountId)
        {
            using (var context = new ClashOfClansContext())
            {
                return (from clan in context.Clan
                        join participation in context.PartecipazioniClan
                        on clan.IdClan equals participation.IdClan
                        where participation.DataFine == null && participation.IdAccount.Equals(accountId)
                        select clan).Any();
            }
        }

        public static List<Clan> GetAllClans()
        {
            using (var context = new ClashOfClansContext())
            {
                return [.. context.Clan
                    .Include(clan => clan.PartecipazioniClan)
                    .Include(clan => clan.Combattimenti)];
            }
        }

        public static void CreateClan(string clanName, Account clanChief)
        {
            using (var context = new ClashOfClansContext())
            {
                try
                {
                    var chiefVillage = VillageDao.GetVillageFromAccount(clanChief);
                    var clanGuid = Guid.NewGuid();
                    context.Clan.Add(new Clan
                    {
                        Nome = clanName,
                        IdClan = clanGuid,
                        NumeroMembri = 1,
                        TrofeiTotali = chiefVillage!.NumeroTrofei,
                        StelleGuerraTotali = chiefVillage.NumeroStelleGuerra
                    });
                    context.PartecipazioniClan.Add(new PartecipazioneClan
                    {
                        IdAccount = clanChief.IdAccount,
                        IdClan = clanGuid,
                        DataInizio = DateTime.Now,
                        Ruolo = Enums.ClanRole.Leader.ToString()
                    });
                    context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine("An error occurred while updating the database (clan creation).");
                    Console.WriteLine($"Exception Message: {ex.Message}");
                    Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                    Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                    throw;
                }
            }
        }

        public static void ChangeClanMemberRole(Guid accountId, Guid clanId, Enums.ClanRole newRole)
        {
            using (var context = new ClashOfClansContext())
            {
                try
                {
                    // First we end the current member's participation in the clan
                    var currentParticipation = context.PartecipazioniClan
                        .First(participation => participation.IdAccount.Equals(accountId)
                            && participation.IdClan.Equals(clanId)
                            && participation.DataFine == null);
                    currentParticipation.DataFine = DateTime.Now;
                    // Now we create the new participation
                    DateTime debugDateTime = DateTime.Now;
                    Console.WriteLine($"Debug DateTime: {debugDateTime} ms: {debugDateTime.Millisecond}");
                    context.PartecipazioniClan.Add(new PartecipazioneClan
                    {
                        IdAccount = accountId,
                        IdClan = clanId,
                        DataInizio = debugDateTime,
                        Ruolo = newRole.ToString()
                    });
                    context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine("An error occurred while updating the database (role change).");
                    Console.WriteLine($"Exception Message: {ex.Message}");
                    Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                    Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                    throw;
                }
            }
        }
        public static void AddMemberToClan(Guid accountId, Guid clanId)
        {
            using (var context = new ClashOfClansContext())
            {
                context.PartecipazioniClan.Add(new PartecipazioneClan
                {
                    IdAccount = accountId,
                    IdClan = clanId,
                    DataInizio = DateTime.Now,
                    Ruolo = Enums.ClanRole.Member.ToString(),
                });
                context.Clan.Find(clanId)!.NumeroMembri++;
                context.SaveChanges();
            }
        }

        public static void RemoveMemberFromClan(Guid accountId, Guid clanId)
        {
            using (var context = new ClashOfClansContext())
            {
                var clan = context.Clan
                    .Include(clan => clan.PartecipazioniClan)
                    .First(clan => clan.IdClan.Equals(clanId));
                var currentParticipation = clan.PartecipazioniClan
                    .First(participation => participation.IdAccount.Equals(accountId)
                        && participation.IdClan.Equals(clanId)
                        && participation.DataFine == null);
                currentParticipation.DataFine = DateTime.Now;
                context.Clan.Find(clanId)!.NumeroMembri--;
                context.SaveChanges();
            }
        }

        public static Clan GetClan(Guid clanId)
        {
            using (var context = new ClashOfClansContext())
            {
                return context.Clan
                    .Include(clan => clan.PartecipazioniClan)
                    .Include(clan => clan.Combattimenti)
                    .First(clan => clan.IdClan.Equals(clanId));
            }
        }

        /// <summary>
        /// Clans suitable for war must not be already in another war, and
        /// must have at least 5 members each.
        /// </summary>
        /// <returns></returns>
        public static List<Clan> GetClansSuitableForWar()
        {
            using (var context = new ClashOfClansContext())
            {
                return (from clan in context.Clan
                        where !(from clan2 in context.Clan // find all clans currently fighting, and choose the clans that
                                join combat in context.Combattimenti // are not in this list
                                on clan2.IdClan equals combat.IdClan
                                join wars in context.Guerre
                                on combat.IdGuerra equals wars.IdGuerra
                                where wars.InCorso == "1"
                                select clan2).Contains(clan)
                        where clan.NumeroMembri >= 5
                        select clan)
                        .Include(clan => clan.PartecipazioniClan)
                        .Include(clan => clan.Combattimenti)
                        .ToList();
            }
        }
    }
}
