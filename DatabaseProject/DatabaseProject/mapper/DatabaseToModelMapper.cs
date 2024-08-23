using DatabaseProject.model.code;

namespace DatabaseProject.mapper
{
    public static class DatabaseToModelMapper
    {
        public static KeyValuePair<Account, database.Account> MapAccount(
            database.Account dbAccount, 
            database.Giocatore player,
            database.Villaggio village
            )
        {
            Account modelAccount = new(
                dbAccount.Username,
                dbAccount.Email,
                dbAccount.IdAccount.ToString()
            );
            return new KeyValuePair<Account, database.Account>(modelAccount, dbAccount);
        }

        public static KeyValuePair<Player, database.Giocatore> MapPlayer(
            database.Giocatore dbPlayer
            )
        {
            Player modelPlayer = new(
                dbPlayer.Nome,
                dbPlayer.Cognome,
                dbPlayer.IdGiocatore.ToString()
            );
            return new KeyValuePair<Player, database.Giocatore>(modelPlayer, dbPlayer);
        }
    }
}
