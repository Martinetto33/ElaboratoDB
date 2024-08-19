using DatabaseProject.context;
using DatabaseProject.database;

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
                var village = new Villaggio
                {
                    IdVillaggio = Guid.NewGuid(),
                    Account = account
                };
                account.IdVillaggio = village.IdVillaggio;
                context.Accounts.Add(account);
                context.Villaggi.Add(village);
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
    }
}
