namespace DatabaseProject.common
{
    public static class Enums
    {
        public enum BuildingType
        {
            Resource,
            Defense,
            Special
        }

        public enum ResourceType
        {
            Gold,
            Elixir,
            DarkElixir
        }

        public enum SpecialBuildingRole
        {
            TownHall,
            ClanCastle,
            Laboratory,
            ArmyCamp
        }

        public enum ClanRole
        {
            Leader,
            CoLeader,
            Elder,
            Member
        }

        public enum AccountRoleInAttack
        {
            Attacker,
            Defender
        }

        public enum ClanOperationResult
        {
            Success,
            CoLeaderPromotion,
            LeaderDemotionAttempt,
            LeaderPromotionAttempt,
            NoSuchMember,
            LeaderRemovalAttempt,
            MemberDemotionAttempt,
            UnknownError
        }
    }
}
