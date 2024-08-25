using DatabaseProject.context;
using DatabaseProject.database;

namespace DatabaseProject.daos
{
    public static class WarDao
    {
        public static void StartWar(Guid warId)
        {
            using var ctx = new ClashOfClansContext();
            var war = ctx.Guerre.Find(warId);
            war!.InCorso = "T";
            ctx.SaveChanges();
        }

        public static void EndWar(Guid warId)
        {
            using var ctx = new ClashOfClansContext();
            var war = ctx.Guerre.Find(warId);
            war!.InCorso = "F";
            ctx.SaveChanges();
        }

        public static List<Clan> GetContenders(Guid warId)
        {
            using var ctx = new ClashOfClansContext();
            return ctx.Combattimenti
                .Where(attack => attack.IdGuerra == warId)
                .Select(attack => attack.IdClanNavigation)
                .Distinct()
                .Take(2)
                .ToList();
        }

        public static ISet<Attacco> GetClanAttacks(Guid warId, Guid clanId)
        {
            using var ctx = new ClashOfClansContext();
            var attacks = from war in ctx.Guerre
                          join attacksInWar in ctx.AttacchiEGuerre on war.IdGuerra equals attacksInWar.IdGuerra
                          join attack in ctx.Attacchi on attacksInWar.IdAttacco equals attack.IdAttacco // take all the attacks in this war
                          join combat in ctx.Combattimenti on war.IdGuerra equals combat.IdGuerra // take all the combats in this war
                          where war.IdGuerra == warId && combat.IdClan == clanId // filter this war and this clan
                          select attack; // take all the attacks
            return attacks.ToHashSet();
        }

        public static List<Guerra> GetAllWars()
        {
            using var ctx = new ClashOfClansContext();
            return [.. ctx.Guerre];
        }
    }
}
