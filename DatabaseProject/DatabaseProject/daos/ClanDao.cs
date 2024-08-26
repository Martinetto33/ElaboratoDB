using DatabaseProject.common;
using DatabaseProject.context;
using DatabaseProject.database;
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
                        select clan).First();
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
                // First we end the current member's participation in the clan
                var currentParticipation = context.PartecipazioniClan
                    .First(participation => participation.IdAccount.Equals(accountId) && participation.IdClan.Equals(clanId));
                currentParticipation.DataFine = DateTime.Now;
                // Now we create the new participation
                context.PartecipazioniClan.Add(new PartecipazioneClan
                {
                    IdAccount = accountId,
                    IdClan = clanId,
                    DataInizio = DateTime.Now,
                    Ruolo = newRole.ToString()
                });
                context.SaveChanges();
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
                    Ruolo = Enums.ClanRole.Member.ToString()
                });
                context.SaveChanges();
            }
        }

        public static void RemoveMemberFromClan(Guid accountId, Guid clanId)
        {
            using (var context = new ClashOfClansContext())
            {
                var currentParticipation = context.PartecipazioniClan
                    .First(participation => participation.IdAccount.Equals(accountId) && participation.IdClan.Equals(clanId));
                currentParticipation.DataFine = DateTime.Now;
                context.SaveChanges();
            }
        }
    }
}
