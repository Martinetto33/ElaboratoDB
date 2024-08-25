using DatabaseProject.database;
using DatabaseProject.context;

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
                var junctionTable = DatabaseEntitiesFactory.CreateAccountVillage(village.IdVillaggio, account.IdAccount);
                context.Accounts.Add(account);
                context.Villaggi.Add(village);
                context.VillaggiAccount.Add(junctionTable);
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
    }
}
