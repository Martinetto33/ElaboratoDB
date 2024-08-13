using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.model
{
    enum ClanRole
    {
        Leader,
        CoLeader,
        Elder,
        Member
    }
    internal class Clan(
        string clanId,
        string name,
        IDictionary<Account, ClanRole> membersAndRoles,
        int totalTrophies,
        int totalStarsWon,
        IList<War> warsFought
    )
    {
        public string ClanId { get; } = clanId;
        public string Name { get; } = name;
        public IDictionary<Account, ClanRole> Members { get; } = membersAndRoles;
        public int TotalTrophies { get; set; } = totalTrophies;
        public int TotalStarsWon { get; set; } = totalStarsWon;
        public IList<War> WarsFought { get; } = warsFought;

        public void AddMember(Account member, ClanRole role = ClanRole.Member)
        {
            this.Members.Add(member, role);
        }

        public void RemoveMember(Account member)
        {
            if (Members.Count(entry => entry.Value == ClanRole.Leader) == 1 && this.Members[member] == ClanRole.Leader)
            {
                Console.WriteLine($"Cannot remove the last leader from clan {this.Name}. First, demote member {member.Username}.");
                return;
            }
            this.Members.Remove(member);
        }

        public void promoteMember(Account member)
        {
            if (this.Members.ContainsKey(member))
            {
                switch (this.Members[member])
                {
                    case ClanRole.Member:
                        this.Members[member] = ClanRole.Elder;
                        break;
                    case ClanRole.Elder:
                        this.Members[member] = ClanRole.CoLeader;
                        break;
                    case ClanRole.CoLeader:
                        this.Members[member] = ClanRole.Leader;
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

        public void demoteMember(Account member)
        {
            if (this.Members.ContainsKey(member))
            {
                switch (this.Members[member])
                {
                    case ClanRole.Leader:
                        this.Members[member] = ClanRole.CoLeader;
                        break;
                    case ClanRole.CoLeader:
                        this.Members[member] = ClanRole.Elder;
                        break;
                    case ClanRole.Elder:
                        this.Members[member] = ClanRole.Member;
                        break;
                    case ClanRole.Member:
                        Console.WriteLine("Cannot demote a member.");
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
