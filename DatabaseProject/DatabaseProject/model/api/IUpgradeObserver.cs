using DatabaseProject.model.code;

namespace DatabaseProject.model.api
{
    public interface IUpgradeObserver<T>
    {
        public void OnUpgrade(T upgradedObject);
    }
}
