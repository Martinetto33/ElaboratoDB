
using DatabaseProject.database;
using System.Transactions;

namespace DatabaseProject.daos
{
    public static class Transactions
    {
        public static Villaggio UpgradeBuildingAndRetrieveVillage(EdificioInVillaggio building, Guid villageGuid, int builderId, Guid accountId)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                // Perform the building upgrade
                UpgradesDao.RegisterBuildingUpgrade(building, villageGuid, builderId);

                // Retrieve the updated village
                Villaggio? updatedVillage = VillageDao.GetVillageFromAccountId(accountId);

                // Complete the transaction
                scope.Complete();

                // Use the updated village as needed
                return updatedVillage ?? throw new NullReferenceException("The updated village is null.");
            }
        }
    }
}

