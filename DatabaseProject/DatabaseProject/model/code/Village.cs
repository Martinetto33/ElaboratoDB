namespace DatabaseProject.model.code
{
    public class Village(
        string villageId,
        int experienceLevel,
        int trophies,
        int warStars,
        ISet<SpecialBuilding> specialBuildings,
        ISet<ResourceExtractor> extractors,
        ISet<Defense> defenses,
        ISet<Builder> builders,
        ISet<Troop> troops
    )
    {
        public string VillageId { get; } = villageId;
        /*
         The strength is a value calculated as the number of stars obtained by the account
        divided by three times the number of war attacks performed by the account.
        It's used by the simulator to determine the probability of winning a war attack.
         */
        private double _strength = 0.0;
        public double Strength { get { return _strength; } }
        public int ExperienceLevel { get; set; } = experienceLevel;
        public int Trophies { get; set; } = trophies;
        public int WarStars { get; set; } = warStars;
        public ISet<SpecialBuilding> SpecialBuildings { get; } = specialBuildings;
        public ISet<ResourceExtractor> Extractors { get; } = extractors;
        public ISet<Defense> Defenses { get; } = defenses;
        public ISet<Builder> Builders { get; } = builders;
        public ISet<Troop> Troops { get; } = troops;

        public Laboratory Laboratory { get; set; } = specialBuildings.OfType<Laboratory>().First();

        /// <summary>
        /// Updates the strength of the village based on the number of attacks performed.
        /// </summary>
        /// <param name="attacksPerformed">The number of performed attacks.</param>
        public void UpdateStrength(int attacksPerformed)
        {
            if (attacksPerformed == 0 || attacksPerformed < 0) return;
            _strength = WarStars / (3.0 * attacksPerformed);
        }

        public void UpgradeBuilding(BaseBuilding building)
        {
            if (Builders.Any(Builder => !Builder.IsBusy))
            {
                var freeBuilder = Builders.First(Builder => !Builder.IsBusy);
                freeBuilder.UpgradeBuilding(building);
            }
        }

        public void UpgradeTroop(Troop troop)
        {
            if (Laboratory.IsBusy)
            {
                Console.WriteLine($"Troop {Laboratory.UpgradingTroop?.Name} is already being upgraded.");
                return;
            }
            Laboratory.UpgradeTroop(troop);
        }
    }
}
