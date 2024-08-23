using DatabaseProject.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.model.code
{
    public class Troop(
        string name,
        int level,
        int healthPoints,
        double damagePerSecond,
        string description
    )
    {
        public string Name { get; } = name;
        public int Level { get; set; } = level;
        public int HealthPoints { get; set; } = healthPoints;
        public double DamagePerSecond { get; set; } = damagePerSecond;
        public string Description { get; } = description;

        public async Task UpgradeAsync(double upgradeTimeInSeconds)
        {
            if (Level < Configuration.MAX_LEVEL)
            {
                // Wait for the troop to upgrade; each upgrade takes 5 seconds per level.
                await Task.Delay((int)(upgradeTimeInSeconds * 1000));
                Level++;
                HealthPoints += 10;
                DamagePerSecond += 5;
                Console.WriteLine($"Troop {Name} has been upgraded to level {Level}.");
            }
        }
    }
}
