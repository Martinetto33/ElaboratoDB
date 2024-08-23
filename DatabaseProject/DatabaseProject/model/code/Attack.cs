namespace DatabaseProject.model.code
{
    public class Attack(string id, Account attacker, Account defender)
    {
        public string Id { get; } = id;
        public int? ObtainedPercentage { get; set; } = null;
        public int? ObtainedStars { get; set; } = null;
        public long? TimeTakenMS { get; set; } = null;
        public int? ObtainedTrophies { get; set; } = null;

        //public string? GetAttackTypeFromAccountPerspective(Account account)
        //{
        //    return account == Attacker ? "Attacco" : account == Defender ? "Difesa" : null;
        //}
    }
}
