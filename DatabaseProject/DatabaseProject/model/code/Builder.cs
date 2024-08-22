using DatabaseProject.config;
using DatabaseProject.model.api;

namespace DatabaseProject.model.code
{
    public class Builder(string villageId, int builderId): IUpgradeObservable<BaseBuilding>
    {
        public string VillageId { get; } = villageId;
        public int BuilderId { get; } = builderId;
        public bool IsBusy { get; set; } = false;
        public BaseBuilding? UpgradingBuilding { get; set; } = null;
        private readonly List<IUpgradeObserver<BaseBuilding>> _observers = [];
        private long _upgradeStartTimestamp = 0;
        private long _upgradeEndTimestamp = 0;

        public async Task UpgradeBuilding(BaseBuilding upgradingBuilding)
        {
            if (IsBusy)
            {
                Console.WriteLine($"Builder {BuilderId} is busy upgrading another building.");
                throw new BuilderBusyException("Builder is busy upgrading another building.");
            }
            else
            {
                IsBusy = true;
                UpgradingBuilding = upgradingBuilding;
                _upgradeStartTimestamp = DateTime.Now.Ticks;
                _upgradeEndTimestamp = _upgradeStartTimestamp + upgradingBuilding.Level * ((long) Configuration.UPGRADE_TIME_PER_LEVEL_SECONDS * 1000L);
                // Wait for the building to upgrade; each upgrade takes 5 seconds per level.
                await upgradingBuilding.UpgradeAsync(upgradingBuilding.Level * Configuration.UPGRADE_TIME_PER_LEVEL_SECONDS);
                Console.WriteLine($"Builder {BuilderId} has finished upgrading {upgradingBuilding.Name} to level {upgradingBuilding.Level}.");
                NotifyObservers();
                _upgradeEndTimestamp = 0;
                _upgradeStartTimestamp = 0;
                IsBusy = false;
                UpgradingBuilding = null;
            }
        }

        public void RegisterObserver(IUpgradeObserver<BaseBuilding> observer) => this._observers.Add(observer);

        public void RemoveObserver(IUpgradeObserver<BaseBuilding> observer) => this._observers.Remove(observer);

        public void NotifyObservers()
        {
            if (this.UpgradingBuilding != null && this._observers.Count > 0)
            {
                this._observers.ForEach(observer => observer.OnUpgrade(UpgradingBuilding));
                this._observers.Clear();
            }
        }

        public long GetRemainingUpgradeTime() => _upgradeEndTimestamp - DateTime.Now.Ticks;

        public long GetUpgradeTime() => _upgradeEndTimestamp - _upgradeStartTimestamp;

        public string? GetUpgradingObjectName() => UpgradingBuilding?.Name;

        public string GetObservableId() => BuilderId.ToString();

        bool IUpgradeObservable<BaseBuilding>.IsBusy() => IsBusy;
    }
}
