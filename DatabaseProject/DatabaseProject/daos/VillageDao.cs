//using DatabaseProject.database;
//using DatabaseProject.context;

//namespace DatabaseProject.daos
//{
//    public static class VillageDao
//    {
//        public static Villaggio GetVillageFromAccount(Account account)
//        {
//            using (var context = new ClashOfClansContext())
//            {
//                Villaggio? village = context.Villaggi.Where(village => village.IdVillaggio == account.IdVillaggio).First();
//                if (village == null)
//                {
//                    Console.WriteLine($"Village not found for account: {account.Username}, creating a new one");
//                    Guid guid = Guid.NewGuid();
//                    village = new() 
//                    {
//                        IdVillaggio = guid,
//                        Account = account
//                    };
//                    account.IdVillaggio = guid;
//                    context.Villaggi.Add(village);
//                    context.SaveChanges();
//                }
//                return village;
//            }
//        }
//    }
//}
