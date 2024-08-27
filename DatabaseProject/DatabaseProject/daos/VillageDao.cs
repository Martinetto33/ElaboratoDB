using DatabaseProject.database;
using DatabaseProject.context;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Diagnostics;

namespace DatabaseProject.daos
{
    public static class VillageDao
    {
        public static Villaggio? GetVillageFromAccount(Account account)
        {
            using (var context = new ClashOfClansContext())
            {
                Villaggio? village = (from dbAccount in context.Account
                                      join accountsAndVillages in context.VillaggiAccount on dbAccount.IdAccount equals accountsAndVillages.IdAccount
                                      join vill in context.Villaggi on accountsAndVillages.IdVillaggio equals vill.IdVillaggio
                                      where dbAccount.IdAccount == account.IdAccount
                                      where vill.IdVillaggio == accountsAndVillages.IdVillaggio
                                      select vill)
                                      .Include(village => village.Costruttori) // The include directive should fetch all entities encapsulated in the virtual methods
                                      .Include(village => village.EdificiInVillaggio)
                                      .Include(village => village.TruppeInVillaggio)
                                      .First();
                return village;
            }
        }

        public static Villaggio? GetVillageFromAccountId(Guid accountId)
        {
            using (var context = new ClashOfClansContext())
            {
                Villaggio? village = null;
                try
                {
                    //context.ChangeTracker.Clear(); // this should clear the cached entities, forcing a new query
                    village = (from vill in context.Villaggi
                               where vill.VillaggioAccount!.IdAccount == accountId
                               select vill)
                                   .Include(village => village.Costruttori) // The include directive should fetch all other relevant data
                                   .Include(village => village.EdificiInVillaggio)
                                   .Include(village => village.TruppeInVillaggio)
                                   .First();
                }
                catch (DbException ex)
                {
                    Console.WriteLine("An error occurred while retrieving the village from the database.");
                    Console.WriteLine($"Exception Message: {ex.Message}");
                    Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                    Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                    throw;
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("An error occurred while retrieving the village from the database.");
                    Console.WriteLine($"Exception Message: {ex.Message}");
                    Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                    Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                    throw;
                }
                return village;
            }
        }

        public static List<Costruttore> GetVillageBuilders(Villaggio village) => GetVillageBuilders(village.IdVillaggio);
        public static List<Costruttore> GetVillageBuilders(Guid villageGuid)
        {
            using (var context = new ClashOfClansContext())
            {
                return context.Costruttori.Where(builder => builder.IdVillaggio == villageGuid).ToList();
            }
        }

        public static List<EdificioInVillaggio> GetVillageBuildings(Villaggio village) => GetVillageBuildings(village.IdVillaggio);
        public static List<EdificioInVillaggio> GetVillageBuildings(Guid villageGuid)
        {
            using (var context = new ClashOfClansContext())
            {
                return context.EdificiInVillaggio.Where(building => building.IdVillaggio == villageGuid).ToList();
            }
        }

        public static List<TruppaInVillaggio> GetVillageTroops(Villaggio village) => GetVillageTroops(village.IdVillaggio);
        public static List<TruppaInVillaggio> GetVillageTroops(Guid villageGuid)
        {
            using (var context = new ClashOfClansContext())
            {
                return context.TruppeInVillaggio.Where(troop => troop.IdVillaggio == villageGuid).ToList();
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
