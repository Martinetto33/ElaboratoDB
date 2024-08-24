//namespace DatabaseProject.daos
//{
//    public static class AttackDao
//    {
//        public static bool IsAttacker(Account account, Attacco attack)
//        {
//            using var ctx = new ClashOfClansContext();
//            return ctx.AccountAttaccanti.Any(a => a.IdAttacco == attack.IdAttacco && a.IdAccount == account.IdAccount);
//        }

//        public static AttackTrophies GetTrophiesFromAttack(Attacco attack)
//        {
//            using var ctx = new ClashOfClansContext();
//            return new AttackTrophies
//                (
//                    ctx.AccountAttaccanti.First(a => a.IdAttacco == attack.IdAttacco).TrofeiOttenuti,
//                    ctx.AccountDifensori.First(a => a.IdAttacco == attack.IdAttacco).TrofeiOttenuti
//                );
//        }
//    }

//    public class AttackTrophies(int attackerTrophies, int defenderTrophies)
//    {
//        public int AttackerTrophies { get; } = attackerTrophies;
//        public int DefenderTrophies { get; } = defenderTrophies;
//    }
//}
