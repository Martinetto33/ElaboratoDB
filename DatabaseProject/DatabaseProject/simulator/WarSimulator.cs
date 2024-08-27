using DatabaseProject.common;
using DatabaseProject.config;
using DatabaseProject.daos;
using DatabaseProject.mapper;
using DatabaseProject.model.code;
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
        private readonly War _war = new(Guid.NewGuid().ToString(),
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
        private readonly Random random = new();

        public bool CanStartWar()
        {
            // There must be at least 5 members in each clan to start a war.
            bool areThereEnoughMembers = clan1Members.Count >= 5 && clan2Members.Count >= 5;
            // The members in the war must be the same number for each clan.
            bool areThereTheSameNumberOfAccounts = clan1Members.Count == clan2Members.Count;
            bool areMembersAMultipleOf5 = clan1Members.Count % 5 == 0 && clan2Members.Count % 5 == 0;
            return areThereEnoughMembers && areThereTheSameNumberOfAccounts && areMembersAMultipleOf5;
        }

        public void LaunchSimulation()
        {
            if (CanStartWar())
            {
                _war.StartWar();
                SimulateWar();
                Clan? winner = GetWinner();
                _war.EndWar(winner != null ? Guid.Parse(winner.ClanId) : null);
            }
        }

        public WarRecap GetWarRecap()
        {
            return new
                (
                    Guid.Parse(_war.WarId), 
                    clan1.Name, 
                    clan2.Name, 
                    _clanScores[clan1].Stars, 
                    _clanScores[clan2].Stars, 
                    _clanScores[clan1].AverageAttackTime, 
                    _clanScores[clan2].AverageAttackTime
                );
        }

        private void SimulateWar()
        {
            int clan1RemainingAttacks = _clansAndAccounts.First().Value.Count * Configuration.ATTACKS_PER_PLAYER_IN_WAR;
            int clan2RemainingAttacks = _clansAndAccounts.Last().Value.Count * Configuration.ATTACKS_PER_PLAYER_IN_WAR;
            while (clan1RemainingAttacks-- > 0)
            {
                Account nextAttacker = FilterAccountsThatCanStillAttack(clan1)[0];
                Account target = ChooseTarget(clan2);
                PerformAttack(clan1, nextAttacker, target);
            }
            while (clan2RemainingAttacks-- > 0)
            {
                Account nextAttacker = FilterAccountsThatCanStillAttack(clan2)[0];
                Account target = ChooseTarget(clan1);
                PerformAttack(clan2, nextAttacker, target);
            }
        }

        private Clan? GetWinner()
        {
            if (_clanScores[clan1].Stars > _clanScores[clan2].Stars)
            {
                return clan1;
            }
            else if (_clanScores[clan1].Stars < _clanScores[clan2].Stars)
            {
                return clan2;
            }
            else
            {
                return null;
            }
        }

        private Account ChooseTarget(Clan enemyClan)
        {
            // Prioritise accounts that have not been attacked yet to maximise the number of stars obtained.
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
            
            // Update scores in the simulator
            _clanScores[attackerClan].Stars += stars;
            _clanScores[attackerClan].AverageAttackTime = CalculateAverageAttackTimeForClan(attackerClan);
            
            UpdateVillageStrengthAfterAttack(attacker, attack);
            
            WriteDataToDatabase
                (
                    newAttack: attack,
                    attackerClan: attackerClan,
                    defenderClan: _war.GetEnemyOf(attackerClan),
                    attacker: attacker,
                    defender: target,
                    averageAttacksTimeOfAttackerClan: _clanScores[attackerClan].AverageAttackTime,
                    attackerStrength: (float)attacker.Village!.Strength
                );
        }

        private void UpdateVillageStrengthAfterAttack(Account attackerVillageOwner, Attack attack)
        {
            int attacksDone = AttackDao.GetAllAccountAttacks(DatabaseToModelMapper.Unmap(attackerVillageOwner)).Count + 1;
            attackerVillageOwner.Village!.WarStars += attack.ObtainedStars!.Value;
            attackerVillageOwner.Village!.UpdateStrength(attacksDone);
        }

        private void WriteDataToDatabase
            (
                Attack newAttack,
                Clan attackerClan,
                Clan defenderClan,
                Account attacker,
                Account defender,
                float averageAttacksTimeOfAttackerClan,
                float attackerStrength
            )
        {
            WarDao.CreateWarAttack
                (
                    DatabaseToModelMapper.Unmap(newAttack),
                    DatabaseToModelMapper.Unmap(attacker),
                    attackerStrength,
                    DatabaseToModelMapper.Unmap(defender),
                    DatabaseToModelMapper.Unmap(attackerClan),
                    DatabaseToModelMapper.Unmap(defenderClan),
                    averageAttacksTimeOfAttackerClan,
                    Guid.Parse(_war.WarId)
                );
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

        private int GetAttacksNumberPerformedByAccountInThisWar(Account account) => this._war.GetAttacksNumber(account);

        private List<Account> FilterAccountsThatCanStillAttack(Clan clan)
        {
            return _clansAndAccounts[clan]
                .Where(account => GetAttacksNumberPerformedByAccountInThisWar(account) < Configuration.ATTACKS_PER_PLAYER_IN_WAR)
                .ToList();
        }
    }

    internal class ClanScore
    {
        public int Stars { get; set; }
        public float AverageAttackTime { get; set; }
    }

    public record WarRecap
        (
            Guid WarId,
            string Clan1Name,
            string Clan2Name,
            int Clan1Stars,
            int Clan2Stars,
            float Clan1AverageAttackTime,
            float Clan2AverageAttackTime
        );
}
