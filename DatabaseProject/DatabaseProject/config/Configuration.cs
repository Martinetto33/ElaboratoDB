namespace DatabaseProject.config
{
    public static class Configuration
    {
        public static readonly double UPGRADE_TIME_PER_LEVEL_SECONDS = 5.0; // the number of seconds per level to upgrade a building or troop

        public static readonly int MAX_LEVEL = 6; // the maximum level for a building or troop

        public static readonly string DB_NAME = "clash_of_clans"; // the name of the database

        public static readonly string CONNECTION_STRING = $"server=localhost;port=3306;database={DB_NAME};user=root";

        public static readonly int BUILDERS_NUMBER = 6; // the number of builders available to the player

        public static readonly int RESOURCE_BUILDINGS_NUMBER = 2; // the number of resource buildings per resource type available to the player

        public static readonly int ARCHER_TOWERS_NUMBER = 4; // the number of archer towers available to the player

        public static readonly int CANNONS_NUMBER = 4; // the number of cannons available to the player

        public static readonly int XBOWS_NUMBER = 2; // the number of xbows available to the player

        public static readonly int INFERNO_TOWERS_NUMBER = 2; // the number of inferno towers available to the player

        public static readonly int WIZARD_TOWERS_NUMBER = 4; // the number of wizard towers available to the player

        public static readonly int AIR_DEFENSES_NUMBER = 4; // the number of air defenses available to the player
    }
}
