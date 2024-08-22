namespace DatabaseProject.model.code
{
    public class Attack(string id, Account attacker, Account defender)
    {
        public string Id { get; } = id;
        public int? ObtainedPercentage { get; set; } = null;
        public int? ObtainedStars { get; set; } = null;
        public long? TimeTakenMS { get; set; } = null;
        public Account Attacker { get; set; } = attacker;
        public Account Defender { get; set; } = defender;
    }
}
