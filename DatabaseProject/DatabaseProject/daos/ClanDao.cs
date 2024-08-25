using DatabaseProject.context;
using DatabaseProject.database;

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
    }
}
