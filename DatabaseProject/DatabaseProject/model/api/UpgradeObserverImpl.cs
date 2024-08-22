namespace DatabaseProject.model.api
{
    public class UpgradeObserverImpl<T>(Action<T> onUpgrade): IUpgradeObserver<T>
    {
        public void OnUpgrade(T upgradedObject) => onUpgrade(upgradedObject);
    }
}
