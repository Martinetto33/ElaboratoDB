using DatabaseProject.model.code;

namespace DatabaseProject.model.api
{
    public interface IUpgradeObserver<in T>
    {
        public void OnUpgrade(T upgradedObject);
    }
}
