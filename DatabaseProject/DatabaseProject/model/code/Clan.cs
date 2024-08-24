using DatabaseProject.common;

namespace DatabaseProject.model.code
{
    public class Clan(
        string clanId,
        string name,
        IDictionary<string, Enums.ClanRole> membersAndRoles,
        int totalTrophies,
        int totalStarsWon
    )
    {
        public string ClanId { get; } = clanId;
        public string Name { get; } = name;
        /// <summary>
        /// Only contains pairs of account IDs and their respective roles in the clan.
        /// This is done for the sake of performance.
        /// </summary>
        public IDictionary<string, Enums.ClanRole> Members { get; } = membersAndRoles;
        public int TotalTrophies { get; set; } = totalTrophies;
        public int TotalStarsWon { get; set; } = totalStarsWon;
        public void AddMember(string accountId, Enums.ClanRole role = Enums.ClanRole.Member) => Members.Add(accountId, role);
        public void RemoveMember(string accountId)
        {
            if (Members.Count(entry => entry.Value == Enums.ClanRole.Leader) == 1 && Members[accountId] == Enums.ClanRole.Leader)
            {
                Console.WriteLine($"Cannot remove the last leader from clan {Name}. First, demote account {accountId}.");
                return;
            }
            Members.Remove(accountId);
        }

        public void PromoteMember(string accountId)
        {
            if (Members.TryGetValue(accountId, out Enums.ClanRole value))
            {
                switch (value)
                {
                    case Enums.ClanRole.Member:
                        Members[accountId] = Enums.ClanRole.Elder;
                        break;
                    case Enums.ClanRole.Elder:
                        Members[accountId] = Enums.ClanRole.CoLeader;
                        break;
                    case Enums.ClanRole.CoLeader:
                        Members[accountId] = Enums.ClanRole.Leader;
                        break;
                    case Enums.ClanRole.Leader:
                        Console.WriteLine("Cannot promote a leader.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Member not found in clan.");
            }
        }

        public void DemoteMember(string accountId)
        {
            if (Members.TryGetValue(accountId, out Enums.ClanRole value))
            {
                switch (value)
                {
                    case Enums.ClanRole.Leader:
                        Members[accountId] = Enums.ClanRole.CoLeader;
                        break;
                    case Enums.ClanRole.CoLeader:
                        Members[accountId] = Enums.ClanRole.Elder;
                        break;
                    case Enums.ClanRole.Elder:
                        Members[accountId] = Enums.ClanRole.Member;
                        break;
                    case Enums.ClanRole.Member:
                        Console.WriteLine("Cannot demote a accountId.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Member not found in clan.");
            }
        }
    }
}
