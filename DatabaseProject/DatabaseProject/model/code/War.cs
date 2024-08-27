using DatabaseProject.daos;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

/**
 * I found out that the database stores a 0 to represent false and a 1 to represent true.
 */

namespace DatabaseProject.model.code
{
    public class War
    {
        public string WarId { get; }
        public IDictionary<Clan, ISet<Attack>> Clans { get; }
        public bool IsInProgress { get; set; }

        public War(string warId, IDictionary<Clan, ISet<Attack>> clans, bool isInProgress)
        {
            this.WarId = warId;
            Debug.Assert(clans.Count == 2);
            this.Clans = clans;
            this.IsInProgress = isInProgress;
        }

        public void StartWar()
        {
            IsInProgress = true;
            var clanIds = Clans.Keys.Select(clan => clan.ClanId).ToList();
            Debug.Assert(clanIds.Count == 2);
            WarDao.CreateWar(Guid.Parse(WarId), Guid.Parse(clanIds[0]), Guid.Parse(clanIds[1]));
        }

        public void EndWar(Guid? winnerClan)
        {
            IsInProgress = false;
            WarDao.EndWar(Guid.Parse(WarId), winnerClan);
        }

        public void AddAttack(Clan clan, Attack attack)
        {
            /* Documentation for out keyword: 
             * https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/out
             */
            if (Clans.TryGetValue(clan, out ISet<Attack>? value))
            {
                value.Add(attack);
            }
            else
            {
                Clans.Add(clan, new HashSet<Attack> { attack });
            }
        }

        public Clan GetEnemyOf(Clan clan) => Clans.Keys.First(key => key != clan);
        
        public bool WasTargetAttacked(Account target)
        {
            var targetClan = Clans.Keys.First(clan => clan.Members.ContainsKey(target.Id));
            return Clans[targetClan].Any(attack => attack.IsDefender(target));
        }

        public float GetAverageAttackTime(Clan clan)
        {
            return (float)this.Clans[clan].Select(attack => attack.TimeTakenMS ?? 0).Average();
        }

        public int GetAttacksNumber(Account account)
        {
            return Clans.Values.SelectMany(attacks => attacks).Count(attack => attack.IsAttacker(account));
        }
    }
}
