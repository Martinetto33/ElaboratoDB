using DatabaseProject.common;
using DatabaseProject.model.code;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Diagnostics;

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
        private readonly Dictionary<Clan, List<Account>> _clansAndAccounts = new Dictionary<Clan, List<Account>>()
        {
            {clan1, clan1Members},
            {clan2, clan2Members}
        };
        private readonly Dictionary<Clan, ClanScore> _clanScores = new Dictionary<Clan, ClanScore>()
        {
            {clan1, new ClanScore { Stars = 0, AverageAttackTime = 0.0f } },
            {clan2, new ClanScore { Stars = 0, AverageAttackTime = 0.0f } }
        };
        private Random random = new Random();

        public bool CanStartWar()
        {
            // There must be at least 5 members in each clan to start a war.
            bool areThereEnoughMembers = clan1Members.Count >= 5 && clan2Members.Count >= 5;
            // The members in the war must be the same number for each clan.
            bool areThereTheSameNumberOfAccounts = clan1Members.Count == clan2Members.Count;
            bool areMembersAMultipleOf5 = clan1Members.Count % 5 == 0 && clan2Members.Count % 5 == 0;
            return areThereEnoughMembers && areThereTheSameNumberOfAccounts && areMembersAMultipleOf5;
        }

        public void StartWar()
        {
            if (CanStartWar())
            {
                _war.StartWar();
            }
        }

        private void BeginSimulation()
        {
            int clan1RemainingAttacks, clan2RemainingAttacks = _clansAndAccounts.First().Value.Count * 2;

        }

        private Account ChooseTarget(Clan enemyClan)
        {
            List<Account> notYetAttackedAccounts = _clansAndAccounts[enemyClan]
                .Where(account => !_war.WasTargetAttacked(account))
                .ToList();
            if (notYetAttackedAccounts.Count == 0)
            {
                int count = _clansAndAccounts[enemyClan].Count;
                return _clansAndAccounts[enemyClan][random.Next(count)];
            }
            else
            {
                int count = notYetAttackedAccounts.Count;
                return notYetAttackedAccounts[random.Next(count)];
            }
        }

        private void PerformAttack(Clan attackerClan, Account attacker, Account target)
        {
            Debug.Assert(attacker.Village != null && target.Village != null);
            int stars = (int)Math.Round(random.Next(3) + attacker.Village.Strength);
            Console.WriteLine($"Attacker {attacker.Username} attacked target {target.Username} and got {stars} stars.");
            DetermineAttackResult(out int percentage, out float attackTime, out int attackerTrophies, out int defenderTrophies, in stars);
            var attack = new Attack(Guid.NewGuid().ToString(), attackerTrophies, defenderTrophies, attacker, target)
            {
                ObtainedPercentage = percentage,
                ObtainedStars = stars,
                TimeTakenMS = Utils.GetMillisFromFloatTimeInMinutes(attackTime)
            };
            _war.AddAttack(attackerClan, attack);
            _clanScores[attackerClan].Stars += stars;
            _clanScores[attackerClan].AverageAttackTime = CalculateAverageAttackTimeForClan(attackerClan);
        }

        private void WriteDataToDatabase
            (
                Attack newAttack,
                Clan attackerClan,
                Account attacker,
                Account target
            )
        {
            // warDao.AddAttack(newAttack, attacker, target, attackerClan);
            /**
             * The war dao needs to:
             * - add the attack in the attack table
             * - update the combat table (obtained stars, number of performed attacks of the attacker clan, average attack time).
             * - update the village with obtained trophies and stars, and also the strength
             */
        }

        private void DetermineAttackResult(
            out int percentage, 
            out float attackTime, 
            out int attackerTrophies,
            out int defenderTrophies,
            in int stars)
        {
            switch (stars)
            {
                case 0:
                    percentage = this.random.Next(50);
                    attackTime = (float)this.random.NextDouble(); // from 0.0 to 1.0
                    attackerTrophies = -this.random.Next(50);
                    defenderTrophies = this.random.Next(50);
                    break;
                case 1:
                    percentage = this.random.Next(50, 100);
                    attackTime = (float)this.random.NextDouble() * 1.5f;
                    attackerTrophies = this.random.Next(15);
                    defenderTrophies = -this.random.Next(15);
                    break;
                case 2:
                    percentage = this.random.Next(50, 100);
                    attackTime = (float)this.random.NextDouble() * 2.0f;
                    attackerTrophies = this.random.Next(30);
                    defenderTrophies = -this.random.Next(30);
                    break;
                case 3:
                    percentage = 100;
                    attackTime = (float) this.random.NextDouble() * 3.0f;
                    attackerTrophies = this.random.Next(50);
                    defenderTrophies = -this.random.Next(50);
                    break;
                default:
                    throw new ArgumentException("Invalid number of stars.");
            }
        }

        private float CalculateAverageAttackTimeForClan(Clan clan)
        {
            return this._war.GetAverageAttackTime(clan);
        }
    }

    internal class ClanScore
    {
        public int Stars { get; set; }
        public float AverageAttackTime { get; set; }
    }
}
