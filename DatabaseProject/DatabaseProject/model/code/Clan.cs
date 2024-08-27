using DatabaseProject.common;
using System.Diagnostics;

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
        private string? _demotedLeaderId = null;
        /// <summary>
        /// Only contains pairs of account IDs and their respective roles in the clan.
        /// This is done for the sake of performance.
        /// </summary>
        public IDictionary<string, Enums.ClanRole> Members { get; } = membersAndRoles;
        public int TotalTrophies { get; set; } = totalTrophies;
        public int TotalStarsWon { get; set; } = totalStarsWon;
        public void AddMember(string accountId, Enums.ClanRole role = Enums.ClanRole.Member) => Members.Add(accountId, role);
        public bool RemoveMember(string accountId)
        {
            if (Members.Count(entry => entry.Value == Enums.ClanRole.Leader) == 1 && Members[accountId] == Enums.ClanRole.Leader)
            {
                Console.WriteLine($"Cannot remove the last leader from clan {Name}. First, demote account {accountId}.");
                return false;
            }
            Members.Remove(accountId);
            return true;
        }

        public Enums.ClanOperationResult PromoteMember(string accountId)
        {
            if (Members.TryGetValue(accountId, out Enums.ClanRole value))
            {
                switch (value)
                {
                    case Enums.ClanRole.Member:
                        Members[accountId] = Enums.ClanRole.Elder;
                        return Enums.ClanOperationResult.Success;
                    case Enums.ClanRole.Elder:
                        Members[accountId] = Enums.ClanRole.CoLeader;
                        return Enums.ClanOperationResult.Success;
                    case Enums.ClanRole.CoLeader:
                        if (Members.Count(member => member.Value == Enums.ClanRole.Leader) == 1)
                        {
                            var previousLeader = Members.FirstOrDefault(entry => entry.Value == Enums.ClanRole.Leader);
                            Members[previousLeader.Key] = Enums.ClanRole.CoLeader;
                            this._demotedLeaderId = previousLeader.Key;
                        }
                        Members[accountId] = Enums.ClanRole.Leader;
                        return Enums.ClanOperationResult.CoLeaderPromotion;
                    case Enums.ClanRole.Leader:
                        Console.WriteLine("Cannot promote a leader.");
                        return Enums.ClanOperationResult.LeaderPromotionAttempt;
                }
                return Enums.ClanOperationResult.UnknownError;
            }
            else
            {
                Console.WriteLine("Member not found in clan.");
                return Enums.ClanOperationResult.NoSuchMember;
            }
        }

        public Enums.ClanOperationResult DemoteMember(string accountId)
        {
            if (Members.TryGetValue(accountId, out Enums.ClanRole value))
            {
                switch (value)
                {
                    case Enums.ClanRole.Leader:
                        Console.WriteLine("Cannot demote a leader!");
                        return Enums.ClanOperationResult.LeaderDemotionAttempt;
                    case Enums.ClanRole.CoLeader:
                        Members[accountId] = Enums.ClanRole.Elder;
                        return Enums.ClanOperationResult.Success;
                    case Enums.ClanRole.Elder:
                        Members[accountId] = Enums.ClanRole.Member;
                        return Enums.ClanOperationResult.Success;
                    case Enums.ClanRole.Member:
                        Console.WriteLine("Cannot demote a member.");
                        return Enums.ClanOperationResult.MemberDemotionAttempt;
                }
                return Enums.ClanOperationResult.UnknownError;
            }
            else
            {
                Console.WriteLine("Member not found in clan.");
                return Enums.ClanOperationResult.NoSuchMember;
            }
        }

        public string? GetAndConsumeDemotedLeaderId()
        {
            if (this._demotedLeaderId != null)
            {
                string idCopy = this._demotedLeaderId;
                this._demotedLeaderId = null;
                return idCopy;
            }
            return null;
        }

        public string? GetLeaderId() => Members.FirstOrDefault(entry => entry.Value == Enums.ClanRole.Leader).Key;

        /// <summary>
        /// Should not be called outside clan panel code.
        /// </summary>
        public void ForceLeaderRemoval()
        {
            Debug.Assert(this.Members.Count == 1 && this.Members.First().Value == Enums.ClanRole.Leader);
            this.Members.Remove(this.Members.First().Key);
        }
    }
}
