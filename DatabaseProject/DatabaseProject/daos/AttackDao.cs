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
    }

    public class AttackTrophies(int attackerTrophies, int defenderTrophies)
    {
        public int AttackerTrophies { get; } = attackerTrophies;
        public int DefenderTrophies { get; } = defenderTrophies;
    }
}
