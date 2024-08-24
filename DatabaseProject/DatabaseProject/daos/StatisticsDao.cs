using DatabaseProject.context;
using DatabaseProject.database;

namespace DatabaseProject.daos
{
    public static class StatisticsDao
    {
        public static StatisticheEdificioMigliorato GetStatisticsForBuildingFromLevelAndName(int level, string name)
        {
            using (var ctx = new ClashOfClansContext())
            {
                return ctx.StatisticheEdificiMigliorati
                    .Where(s => s.LivelloMiglioramento == level && s.Nome == name)
                    .FirstOrDefault() ?? throw new Exception($"No statistics found for building {name} of level {level}.");
            }
        }

        public static StatisticheTruppaMigliorata GetStatisticsForTroopFromLevelAndName(int level, string name)
        {
            using (var ctx = new ClashOfClansContext())
            {
                return ctx.StatisticheTruppeMigliorate
                    .Where(s => s.LivelloMiglioramento == level && s.Nome == name)
                    .FirstOrDefault() ?? throw new Exception($"No statistics found for troop {name} of level {level}.");
            }
        }
    }
}
