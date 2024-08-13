using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.model
{
    public class Troop(
        string villageId,
        string name,
        int level,
        int healthPoints,
        double damagePerSecond,
        string description
    )
    {
        public string VillageId { get; } = villageId;
        public string Name { get; } = name;
        public int Level { get; set; } = level;
        public int HealthPoints { get; set; } = healthPoints;
        public double DamagePerSecond { get; set; } = damagePerSecond;
        public string Description { get; } = description;

        public async Task UpgradeAsync(int upgradeTimeInSeconds)
        {
            // Wait for the troop to upgrade; each upgrade takes 5 seconds per level.
            await Task.Delay(upgradeTimeInSeconds * 1000);
            this.Level++;
            this.HealthPoints += 10;
            this.DamagePerSecond += 5;
            Console.WriteLine($"Troop {this.Name} has been upgraded to level {this.Level}.");
        }
    }
}
