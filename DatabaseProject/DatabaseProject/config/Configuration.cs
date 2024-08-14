namespace DatabaseProject.config
{
    public static class Configuration
    {
        public static readonly double UPGRADE_TIME_PER_LEVEL = 5.0; // the number of seconds per level to upgrade a building or troop

        public static readonly int MAX_LEVEL = 6; // the maximum level for a building or troop

        public static readonly string DB_NAME = "clash_of_clans"; // the name of the database

        public static readonly string CONNECTION_STRING = $"server=localhost;port=3306;database={DB_NAME};user=root";
    }
}
