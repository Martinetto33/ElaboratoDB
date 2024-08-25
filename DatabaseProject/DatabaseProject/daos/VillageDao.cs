using DatabaseProject.database;
using DatabaseProject.context;

namespace DatabaseProject.daos
{
    public static class VillageDao
    {
        public static Villaggio? GetVillageFromAccount(Account account)
        {
            using (var context = new ClashOfClansContext())
            {
                Villaggio? village = (from vill in context.Villaggi
                                      join accountsAndVillages in context.VillaggiAccount on vill.IdVillaggio equals accountsAndVillages.IdVillaggio
                                      where vill.IdVillaggio == accountsAndVillages.IdVillaggio
                                      select vill).First();
                return village;
            }
        }

        public static Villaggio? GetVillageFromAccountId(Guid accountId)
        {
            using (var context = new ClashOfClansContext())
            {
                Villaggio? village = (from vill in context.Villaggi
                                      join accountsAndVillages in context.VillaggiAccount
                                      on accountId equals accountsAndVillages.IdAccount
                                      where vill.IdVillaggio == accountsAndVillages.IdVillaggio
                                      select vill).First();
                return village;
            }
        }

        public static void CreateVillageForAccount(Account account)
        {
            using (var context = new ClashOfClansContext())
            {
                var village = DatabaseEntitiesFactory.CreateVillage(account);
                var junctionTable = DatabaseEntitiesFactory.CreateAccountVillage(village.IdVillaggio, account.IdAccount);
                context.Villaggi.Add(village);
                context.VillaggiAccount.Add(junctionTable);
                context.Costruttori.AddRange(village.Costruttori);
                context.EdificiInVillaggio.AddRange(village.EdificiInVillaggio);
                context.TruppeInVillaggio.AddRange(village.TruppeInVillaggio);
                context.SaveChanges();
            }
        }
    }
}
