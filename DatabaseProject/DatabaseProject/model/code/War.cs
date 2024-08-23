using DatabaseProject.daos;

namespace DatabaseProject.model.code
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
            IsInProgress = true;
            WarDao.StartWar(Guid.Parse(WarId));
        }

        public void EndWar()
        {
            IsInProgress = false;
            WarDao.EndWar(Guid.Parse(WarId));
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
    }
}
