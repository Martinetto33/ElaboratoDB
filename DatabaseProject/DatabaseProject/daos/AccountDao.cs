using DatabaseProject.database;
using DatabaseProject.context;
using Microsoft.EntityFrameworkCore;

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
    }
}
