namespace DatabaseProject.model.api
{
    public interface IUpgradeObservable<T>
    {
        public void RegisterObserver(IUpgradeObserver<T> observer);
        public bool RemoveObserver(IUpgradeObserver<T> observer);
        public void NotifyObservers();
        public long GetRemainingUpgradeTime();
        public long GetUpgradeTime();
        public string? GetUpgradingObjectName();
        public string GetObservableId();
        public bool IsBusy();
    }
}
