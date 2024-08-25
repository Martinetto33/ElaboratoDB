using DatabaseProject.context;
using DatabaseProject.database;

namespace DatabaseProject.daos
{
    public static class AttackDao
    {
        public static bool IsAttacker(Account account, Attacco attack)
        {
            using var ctx = new ClashOfClansContext();
            return ctx.AccountAttaccanti.Any(a => a.IdAttacco == attack.IdAttacco && a.IdAccount == account.IdAccount);
        }

        public static AttackTrophies GetTrophiesFromAttack(Attacco attack)
        {
            using var ctx = new ClashOfClansContext();
            return new AttackTrophies
                (
                    attack.TrofeiAttaccante,
                    attack.TrofeiDifensore
                );
        }

        public static List<Attacco> GetAllAccountAttacks(Account account) => GetAllAccountAttacks(account.IdAccount);

        public static List<Attacco> GetAllAccountAttacks(Guid accountId)
        {
            using var ctx = new ClashOfClansContext();
            var attacksDone = from attack in ctx.Attacchi
                              join attacker in ctx.AccountAttaccanti on attack.IdAttacco equals attacker.IdAttacco
                              where attacker.IdAccount == accountId
                              select attack;
            return attacksDone?.ToList() ?? [];
        }
        public static List<Attacco> GetAllAccountDefenses(Account account) => GetAllAccountDefenses(account.IdAccount);
        public static List<Attacco> GetAllAccountDefenses(Guid accountId)
        {
            using var ctx = new ClashOfClansContext();
            var defensesDone = from attack in ctx.Attacchi
                               join defender in ctx.AccountDifensori on attack.IdAttacco equals defender.IdAttacco
                               where defender.IdAccount == accountId
                               select attack;
            return defensesDone?.ToList() ?? [];
        }
    }

    public class AttackTrophies(int attackerTrophies, int defenderTrophies)
    {
        public int AttackerTrophies { get; } = attackerTrophies;
        public int DefenderTrophies { get; } = defenderTrophies;
    }
}
