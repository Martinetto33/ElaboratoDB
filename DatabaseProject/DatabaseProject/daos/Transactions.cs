
using DatabaseProject.common;
using DatabaseProject.context;
using DatabaseProject.database;
using Microsoft.EntityFrameworkCore;
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

        public static void RegisterBuildingUpgradeWithCallback(EdificioInVillaggio building, Guid villageGuid, int builderId, Action callback)
        {
            RegisterBuildingUpgradeAsync(building, villageGuid, builderId)
                .ContinueWith(task =>
                {
                    if (task.IsCompletedSuccessfully)
                    {
                        callback();
                    }
                    else if (task.IsFaulted)
                    {
                        // Handle exceptions
                        Console.WriteLine("An error occurred: " + task.Exception?.GetBaseException().Message);
                    }
                });
        }

        public static async Task RegisterBuildingUpgradeAsync(EdificioInVillaggio building, Guid villageGuid, int builderId)
        {
            int xp = GenerateXPForBuildingUpgrade(building.LivelloMiglioramento);
            using (var context = new ClashOfClansContext())
            {
                using (var transaction = await context.Database.BeginTransactionAsync().ConfigureAwait(false))
                {
                    try
                    {
                        await context.MiglioramentiEdificio.AddAsync(new()
                        {
                            IdVillaggio = villageGuid,
                            IdEdificio = building.IdEdificio,
                            DurataMs = 5000 * building.LivelloMiglioramento,
                            Costo = 100 * building.LivelloMiglioramento,
                            LivelloMiglioramento = building.LivelloMiglioramento,
                            PuntiEsperienzaConferiti = xp,
                            IdCostruttore = builderId
                        }).ConfigureAwait(false);

                        // Attribute xp points to the village
                        var village = await context.Villaggi.FindAsync(villageGuid).ConfigureAwait(false);
                        if (village != null)
                        {
                            village.LivelloEsperienza += xp;
                        }

                        var villageBuildingToUpgrade = await context.EdificiInVillaggio.FindAsync(villageGuid, building.IdEdificio).ConfigureAwait(false);
                        if (villageBuildingToUpgrade != null)
                        {
                            villageBuildingToUpgrade.LivelloMiglioramento = building.LivelloMiglioramento;
                            switch (Enum.Parse<Enums.BuildingType>(building.Categoria))
                            {
                                case Enums.BuildingType.Defense:
                                    villageBuildingToUpgrade.NumeroBersagli = building.NumeroBersagli;
                                    villageBuildingToUpgrade.RaggioAzione = building.RaggioAzione;
                                    villageBuildingToUpgrade.DanniAlSecondo = building.DanniAlSecondo;
                                    break;
                                case Enums.BuildingType.Resource:
                                    villageBuildingToUpgrade.ProduzioneOraria = building.ProduzioneOraria;
                                    break;
                                case Enums.BuildingType.Special:
                                    break;
                                default:
                                    throw new ArgumentException($"No suitable building type found for {building.Nome} with type: {building.Categoria}");
                            }
                        }

                        await context.SaveChangesAsync().ConfigureAwait(false);
                        await transaction.CommitAsync().ConfigureAwait(false);
                    }
                    catch (DbUpdateException ex)
                    {
                        Console.WriteLine("An error occurred while updating the database (building upgrade).");
                        Console.WriteLine($"Exception Message: {ex.Message}");
                        Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                        Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                        await transaction.RollbackAsync().ConfigureAwait(false);
                        throw;
                    }
                }
            }
        }

        private static int GenerateXPForBuildingUpgrade(int upgradeLevel)
        {
            int variance = upgradeLevel * 100;
            int randomOffset = new Random().Next(-variance, variance + 1);
            return 1000 * upgradeLevel + randomOffset;
        }
    }
}

