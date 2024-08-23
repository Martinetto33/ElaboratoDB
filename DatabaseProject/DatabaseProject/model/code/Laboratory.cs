using DatabaseProject.config;
using DatabaseProject.model.api;

namespace DatabaseProject.model.code
{
    public class Laboratory(
        int buildingId,
        string name,
        int level,
        int healthPoints,
        string description
    ) : SpecialBuilding(buildingId, name, level, healthPoints, description, SpecialBuildingRole.Laboratory), IUpgradeObservable<Troop>
    {
        public bool IsBusy { get; set; } = false;
        public Troop? UpgradingTroop { get; set; } = null;
        private readonly List<IUpgradeObserver<Troop>> _observers = [];
        private long _upgradeStartTimestamp = 0;
        private long _upgradeEndTimestamp = 0;

        public async Task UpgradeTroop(Troop troop)
        {
            if (IsBusy)
            {
                Console.WriteLine($"Laboratory is busy upgrading troop: {UpgradingTroop?.Name}.");
                throw new LaboratoryBusyException("Laboratory is busy upgrading another troop.");
            }
            UpgradingTroop = troop;
            IsBusy = true;
            _upgradeStartTimestamp = GetCurrentTimeInMilliseconds();
            _upgradeEndTimestamp = _upgradeStartTimestamp + troop.Level * ((long)Configuration.UPGRADE_TIME_PER_LEVEL_SECONDS * 1000L);
            // Wait for the troop to upgrade; each upgrade takes 5 seconds per level.
            await troop.UpgradeAsync(troop.Level * Configuration.UPGRADE_TIME_PER_LEVEL_SECONDS);
            Console.WriteLine($"Laboratory has finished upgrading {troop.Name} to level {troop.Level}.");
            NotifyObservers();
            _upgradeEndTimestamp = 0;
            _upgradeStartTimestamp = 0;
            UpgradingTroop = null;
            IsBusy = false;
        }

        public void RegisterObserver(IUpgradeObserver<Troop> observer) => this._observers.Add(observer);

        public bool RemoveObserver(IUpgradeObserver<Troop> observer) => this._observers.Remove(observer);

        public void NotifyObservers()
        {
            if (this.UpgradingTroop != null && this._observers.Count > 0)
            {
                this._observers.ForEach(observer => observer.OnUpgrade(UpgradingTroop));
            }
        }

        private long GetCurrentTimeInMilliseconds() => DateTimeOffset.Now.ToUnixTimeMilliseconds();
        public long GetRemainingUpgradeTime() => _upgradeEndTimestamp - GetCurrentTimeInMilliseconds();

        public long GetUpgradeTime() => _upgradeEndTimestamp - _upgradeStartTimestamp;

        public string? GetUpgradingObjectName() => UpgradingTroop?.Name;

        public string GetObservableId() => "Laboratory";

        bool IUpgradeObservable<Troop>.IsBusy() => IsBusy;
    }
}
