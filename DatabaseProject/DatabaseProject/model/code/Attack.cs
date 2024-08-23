﻿namespace DatabaseProject.model.code
{
    public class Attack(string id, int attackerTrophies, int defenderTrophies)
    {
        public string Id { get; } = id;
        public int? ObtainedPercentage { get; set; } = null;
        public int? ObtainedStars { get; set; } = null;
        public long? TimeTakenMS { get; set; } = null;
        private readonly int _attackerTrophies = attackerTrophies;
        private readonly int _defenderTrophies = defenderTrophies;
        public int GetObtainedTrophies(Account account) => 
            IsAttacker(account) ? _attackerTrophies : _defenderTrophies;

        private bool IsAttacker(Account account)
        {
            // TODO: unmap this account and query the database to see if it is contained in the AccountAttaccante
            // table.
            return false;
        }

        public string GetAttackType(Account account) => IsAttacker(account) ? "Attack" : "Defense";
    }
}
