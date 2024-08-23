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
                var village = DatabaseEntitiesFactory.CreateVillage(account);
                account.IdVillaggio = village.IdVillaggio;
                context.Accounts.Add(account);
                foreach (var builder in village.Costruttori)
                {
                    context.Costruttori.Add(builder);
                }
                foreach (var building in village.Edifici)
                {
                    context.Edifici.Add(building);
                }
                foreach (var troop in village.Truppe)
                {
                    context.Truppe.Add(troop);
                }
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

        public static List<Account> GetAccountsFromPlayer(Giocatore player)
        {
            using (var context = new ClashOfClansContext())
            {
                return context.Accounts.Where(account => account.IdGiocatore == player.IdGiocatore).ToList();
            }
        }
    }
}
