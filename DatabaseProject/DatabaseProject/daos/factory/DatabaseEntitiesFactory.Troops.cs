using DatabaseProject.database;

namespace DatabaseProject.daos
{
    public static partial class DatabaseEntitiesFactory
    {
        public static TruppaInVillaggio CreateTroop(Guid villageGuid, string troopType)
        {
            if (TroopNameDao.IsTroopNameValid(troopType))
            {
                return new TruppaInVillaggio()
                {
                    IdVillaggio = villageGuid,
                    Livello = 1,
                    Nome = troopType,
                };
            }
            throw new Exception($"Invalid troop type: {troopType}");
        }
    }
}
