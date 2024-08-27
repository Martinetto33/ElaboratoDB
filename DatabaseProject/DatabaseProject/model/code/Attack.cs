using DatabaseProject.common;
using DatabaseProject.daos;
using System.Reflection.Metadata.Ecma335;

namespace DatabaseProject.model.code
{
    public class Attack(string id, int attackerTrophies, int defenderTrophies, Account attacker, Account defender)
    {
        public string Id { get; } = id;
        public int? ObtainedPercentage { get; set; } = null;
        public int? ObtainedStars { get; set; } = null;
        public long? TimeTakenMS { get; set; } = null;
        private readonly int _attackerTrophies = attackerTrophies;
        private readonly int _defenderTrophies = defenderTrophies;
        private readonly Account _attacker = attacker;
        private readonly Account _defender = defender;
        public int GetObtainedTrophies(Account account) => 
            IsAttacker(account) ? _attackerTrophies : _defenderTrophies;

        public bool IsAttacker(Account account) => _attacker.Equals(account);

        public bool IsDefender(Account account) => _defender.Equals(account);

        public AttackTrophies GetAttackerAndDefenderTrophies() => new (_attackerTrophies, _defenderTrophies);

        public Enums.AccountRoleInAttack GetAttackType(Account account) => 
            IsAttacker(account) ? Enums.AccountRoleInAttack.Attacker : Enums.AccountRoleInAttack.Defender;
    }
}
