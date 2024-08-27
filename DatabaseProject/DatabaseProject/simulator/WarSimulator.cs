using DatabaseProject.model.code;

namespace DatabaseProject.simulator
{
    public class WarSimulator
        (
            Clan clan1, 
            Clan clan2, 
            List<Account> clan1Members, 
            List<Account> clan2Members
        )
    {
        private War _war = new(Guid.NewGuid().ToString(),
            new Dictionary<Clan, ISet<Attack>>()
            {
                {clan1, new HashSet<Attack>()},
                {clan2, new HashSet<Attack>()}
            },
            isInProgress: false
            );
        private Clan _clan1 = clan1;
        private Clan _clan2 = clan2;
        private List<Account> _clan1Members = clan1Members;
        private List<Account> _clan2Members = clan2Members;

        public bool CanStartWar()
        {
            // There must be at least 5 members in each clan to start a war.
            bool areThereEnoughMembers = _clan1Members.Count >= 5 && _clan2Members.Count >= 5;
            // The members in the war must be the same number for each clan.
            bool areThereTheSameNumberOfAccounts = _clan1Members.Count == _clan2Members.Count;
            bool areMembersAMultipleOf5 = _clan1Members.Count % 5 == 0 && _clan2Members.Count % 5 == 0;
            return areThereEnoughMembers && areThereTheSameNumberOfAccounts && areMembersAMultipleOf5;
        }

        public void StartWar()
        {
            if (CanStartWar())
            {
                _war.StartWar();
            }
        }
    }
}
