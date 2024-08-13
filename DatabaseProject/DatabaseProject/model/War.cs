using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.model
{
    public class War(
        string warId,
        IDictionary<Clan, ISet<Attack>> clans,
        bool isInProgress
    )
    {
        public string WarId { get; } = warId;
        public IDictionary<Clan, ISet<Attack>> Clans { get; } = clans;
        public bool IsInProgress { get; set; } = isInProgress;

        public void StartWar()
        {
            this.IsInProgress = true;
        }

        public void EndWar()
        {
            this.IsInProgress = false;
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
                this.Clans.Add(clan, new HashSet<Attack> { attack });
            }
        }
    }
}
