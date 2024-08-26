using DatabaseProject.common;
using DatabaseProject.context;
using DatabaseProject.database;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace DatabaseProject.daos
{
    public static class UpgradesDao
    {
        public static void RegisterTroopUpgrade(TruppaInVillaggio troop, Guid villageGuid)
        {
            using (var context = new ClashOfClansContext())
            {
                try
                {
                    context.MiglioramentiTruppa.Add(new()
                    {
                        IdVillaggio = villageGuid,
                        NomeTruppa = troop.Nome,
                        LivelloMiglioramento = troop.Livello
                    });
                    // Attribute xp points to the village
                    int experiencePoints = (from stats in context.StatisticheTruppeMigliorate
                                            where stats.Nome == troop.Nome && stats.LivelloMiglioramento == troop.Livello
                                            select stats.PuntiEsperienzaConferiti).First();
                    context.Villaggi.Find(villageGuid)!.LivelloEsperienza += experiencePoints;
                    context.TruppeInVillaggio.Find(villageGuid, troop.Nome)!.Livello = troop.Livello;
                    context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine("An error occurred while updating the database (troop upgrade).");
                    Console.WriteLine($"Exception Message: {ex.Message}");
                    Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                    Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                    throw;
                }
            }
        }

        public static void RegisterBuildingUpgrade(EdificioInVillaggio building, Guid villageGuid, int builderId)
        {
            int xp = GenerateXPForBuildingUpgrade(building.LivelloMiglioramento);
            using (var context = new ClashOfClansContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.MiglioramentiEdificio.Add(new()
                        {
                            IdVillaggio = villageGuid,
                            IdEdificio = building.IdEdificio,
                            DurataMs = 5000 * building.LivelloMiglioramento,
                            Costo = 100 * building.LivelloMiglioramento,
                            LivelloMiglioramento = building.LivelloMiglioramento,
                            PuntiEsperienzaConferiti = xp,
                            IdCostruttore = builderId
                        });
                        // Attribute xp points to the village
                        context.Villaggi.Find(villageGuid)!.LivelloEsperienza += xp;
                        var villageBuildingToUpgrade = context.EdificiInVillaggio.Find(villageGuid, building.IdEdificio)!;
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
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (DbUpdateException ex)
                    {
                        Console.WriteLine("An error occurred while updating the database (building upgrade).");
                        Console.WriteLine($"Exception Message: {ex.Message}");
                        Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                        Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                        transaction.Rollback();
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
