using DatabaseProject.context;
using DatabaseProject.database;

namespace DatabaseProject.daos
{
    public static class PlayerDao
    {
        public static void CreatePlayer(string name, string surname)
        {
            using (var context = new ClashOfClansContext())
            {
                var player = new Giocatore
                {
                    Nome = name,
                    Cognome = surname,
                    IdGiocatore = Guid.NewGuid()
                };
                context.Giocatori.Add(player);
                context.SaveChanges();
            }
        }

        public static List<Giocatore> GetAllPlayers()
        {
            using (var context = new ClashOfClansContext())
            {
                return [.. context.Giocatori];
            }
        }

        public static Giocatore GetPlayerFromAccountId(Guid accountId)
        {
            using (var context = new ClashOfClansContext())
            {
                return (from account in context.Accounts
                        join player in context.Giocatori 
                        on account.IdGiocatore equals player.IdGiocatore
                        where account.IdAccount == accountId
                        select player).First();
            }
        }
    }
}
