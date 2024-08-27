using DatabaseProject.context;
using DatabaseProject.database;

namespace DatabaseProject.daos
{
    public static class WarDao
    {
        public static void CreateWar(Guid warId, Guid clan1, Guid clan2)
        {
            using var ctx = new ClashOfClansContext();
            var war = new Guerra
            {
                IdGuerra = warId,
                InCorso = "1"
            };
            ctx.Guerre.Add(war);
            var combat1 = new Combattimento
            {
                IdClan = clan1,
                IdGuerra = war.IdGuerra,
                StelleOttenute = 0,
                AttacchiEffettuati = 0,
                TempoMedioAttacco = 0.0f,
                Vincitore = "0"
            };
            var combat2 = new Combattimento
            {
                IdClan = clan2,
                IdGuerra = war.IdGuerra,
                StelleOttenute = 0,
                AttacchiEffettuati = 0,
                TempoMedioAttacco = 0.0f,
                Vincitore = "0"
            };
            ctx.Add(combat1);
            ctx.Add(combat2);
            ctx.SaveChanges();
        }

        public static List<Combattimento> GetCombatsFromWar(Guid warId)
        {
            using var context = new ClashOfClansContext();
            return [.. context.Combattimenti.Where(combat => combat.IdGuerra == warId)];
        }

        /// <summary>
        /// WinnerClan is nullable because wars may end in a draw.
        /// </summary>
        /// <param name="warId"></param>
        /// <param name="winnerClan"></param>
        public static void EndWar(Guid warId, Guid? winnerClan)
        {
            using var ctx = new ClashOfClansContext();
            var war = ctx.Guerre.Find(warId);
            war!.InCorso = "0";
            ctx.Combattimenti
                .First(combat => combat.IdGuerra == warId && combat.IdClan == winnerClan)!
                .Vincitore = "1";
            ctx.SaveChanges();
        }

        public static List<Clan> GetContenders(Guid warId)
        {
            using var ctx = new ClashOfClansContext();
            return ctx.Combattimenti
                .Where(combat => combat.IdGuerra == warId)
                .Select(combat => combat.IdClanNavigation)
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
