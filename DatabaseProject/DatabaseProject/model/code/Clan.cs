using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.model.code
{
    public enum ClanRole
    {
        Leader,
        CoLeader,
        Elder,
        Member
    }
    public class Clan(
        string clanId,
        string name,
        IDictionary<string, ClanRole> membersAndRoles,
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
        public IDictionary<string, ClanRole> Members { get; } = membersAndRoles;
        public int TotalTrophies { get; set; } = totalTrophies;
        public int TotalStarsWon { get; set; } = totalStarsWon;
        public void AddMember(string accountId, ClanRole role = ClanRole.Member) => Members.Add(accountId, role);
        public void RemoveMember(string accountId)
        {
            if (Members.Count(entry => entry.Value == ClanRole.Leader) == 1 && Members[accountId] == ClanRole.Leader)
            {
                Console.WriteLine($"Cannot remove the last leader from clan {Name}. First, demote account {accountId}.");
                return;
            }
            Members.Remove(accountId);
        }

        public void PromoteMember(string accountId)
        {
            if (Members.TryGetValue(accountId, out ClanRole value))
            {
                switch (value)
                {
                    case ClanRole.Member:
                        Members[accountId] = ClanRole.Elder;
                        break;
                    case ClanRole.Elder:
                        Members[accountId] = ClanRole.CoLeader;
                        break;
                    case ClanRole.CoLeader:
                        Members[accountId] = ClanRole.Leader;
                        break;
                    case ClanRole.Leader:
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
            if (Members.TryGetValue(accountId, out ClanRole value))
            {
                switch (value)
                {
                    case ClanRole.Leader:
                        Members[accountId] = ClanRole.CoLeader;
                        break;
                    case ClanRole.CoLeader:
                        Members[accountId] = ClanRole.Elder;
                        break;
                    case ClanRole.Elder:
                        Members[accountId] = ClanRole.Member;
                        break;
                    case ClanRole.Member:
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
