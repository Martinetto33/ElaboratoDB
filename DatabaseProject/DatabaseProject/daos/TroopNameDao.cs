using DatabaseProject.context;

namespace DatabaseProject.daos
{
    public static class TroopNameDao
    {
        /// <summary>
        /// Checks if the provided string represents a valid troop name.
        /// </summary>
        /// <param name="name">The name of a troop as registered in the database.
        /// Examples are "Barbaro", "Arciere", "Stregone" and so on.</param>
        /// <returns></returns>
        public static bool IsTroopNameValid(string name)
        {
            using (var ctx = new ClashOfClansContext())
            {
                return (from troopPrototype in ctx.TipiTruppe
                        where troopPrototype.Nome == name
                        select troopPrototype).Any();
            }
        }

        public static string GetTroopDescriptionFromName(string name)
        {
            if (!IsTroopNameValid(name))
            {
                throw new Exception($"No troop found with name {name}.");
            }
            using (var ctx = new ClashOfClansContext())
            {
                return (from troopPrototype in ctx.TipiTruppe
                        where troopPrototype.Nome == name
                        select troopPrototype.Descrizione).First();
            }
        }
    }
}
