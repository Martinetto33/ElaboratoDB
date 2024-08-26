using DatabaseProject.database;
using DatabaseProject.context;
using Microsoft.EntityFrameworkCore;
using DatabaseProject.common;

namespace DatabaseProject.daos
{
    public static class AccountDao
    {
        // Account creation requires a village creation
        public static void CreateAccount(Giocatore owner, string username, string email)
        {
            using (var context = new ClashOfClansContext())
            {
                var account = new Account
                {
                    Username = username,
                    Email = email,
                    IdAccount = Guid.NewGuid(),
                    IdGiocatore = owner.IdGiocatore
                };
                var village = DatabaseEntitiesFactory.CreateVillage(account);
                context.Accounts.Add(account);
                context.Villaggi.Add(village);
                context.Costruttori.AddRange(village.Costruttori);
                context.EdificiInVillaggio.AddRange(village.EdificiInVillaggio);
                context.TruppeInVillaggio.AddRange(village.TruppeInVillaggio);
                context.SaveChanges();
            }
        }

        public static List<Account> GetAllAccounts()
        {
            using (var context = new ClashOfClansContext())
            {
                return [.. context.Accounts];
            }
        }

        public static List<Account> GetAllAccountsFromAccountIds(List<Guid> accountIds)
        {
            using (var context = new ClashOfClansContext())
            {
                return [.. context.Accounts.Where(account => accountIds.Contains(account.IdAccount))];
            }
        }

        public static List<Account> GetAccountsFromPlayer(Giocatore player)
        {
            using (var context = new ClashOfClansContext())
            {
                return [.. context.Accounts.Where(account => account.IdGiocatore == player.IdGiocatore)];
            }
        }

        public static Account? GetAccountFromId(Guid accountId)
        {
            using (var context = new ClashOfClansContext())
            {
                return context.Accounts.Find(accountId);
            }
        }

        public static List<Account> GetAccountsWithoutAClan()
        {
            using (var context = new ClashOfClansContext())
            {
                return (from account in context.Accounts
                        where !( // LINQ equivalent of NOT IN
                                from participations in context.PartecipazioniClan
                                where participations.DataFine == null
                                select participations.IdAccount
                                ).Contains(account.IdAccount)
                        select account).ToList();
            }
        }

        public static Dictionary<Account, Enums.ClanRole> GetAllAccountsInClan(Guid clanId)
        {
            using (var context = new ClashOfClansContext())
            {
                return (from account in context.Accounts
                       join partecipazioni in context.PartecipazioniClan on account.IdAccount equals partecipazioni.IdAccount
                       where partecipazioni.IdClan == clanId && partecipazioni.DataFine == null
                       select new // The C# way to select multiple columns
                       {
                           Account = account,
                           Role = Enum.Parse<Enums.ClanRole>(partecipazioni.Ruolo)
                       }).ToDictionary(pair => pair.Account, pair => pair.Role);
            }
        }

        public static Dictionary<Account, KeyValuePair<int, int>> GetStarsAndTrophiesFromAccounts(List<Account> accounts)
        {
            using var context = new ClashOfClansContext();
            return (from account in accounts
                    join accountsVillage in context.VillaggiAccount
                    on account.IdAccount equals accountsVillage.IdAccount
                    join village in context.Villaggi
                    on accountsVillage.IdVillaggio equals village.IdVillaggio
                    orderby village.NumeroTrofei descending
                    select new
                    {
                        Account = account,
                        Stars = village.NumeroStelleGuerra,
                        Trophies = village.NumeroTrofei
                    }).ToDictionary(pair => pair.Account, pair => new KeyValuePair<int, int>(pair.Trophies, pair.Stars));
        }
    }
}
