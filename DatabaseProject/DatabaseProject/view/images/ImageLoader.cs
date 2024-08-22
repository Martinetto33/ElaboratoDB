using System.Collections.Immutable;
using System.Reflection;

namespace DatabaseProject.view.images
{
    /// <summary>
    /// A class used to fetch images dynamically from a folder defined by the programmer.
    /// Remember to right click the images in the myresources folder and set the 
    /// Build Action to Embedded Resource.
    /// </summary>
    public static class ImageLoader
    {
        private static readonly string basePath = "DatabaseProject.myresources";
        private static readonly string troopPath = "troops";
        private static readonly string buildingPath = "buildings";
        private static readonly List<string> troopImagePaths =
            [
                "archer.png",
                "balloon.png",
                "barbarian.png",
                "dragon.png",
                "giant.png",
                "goblin.png",
                "healer.png",
                "pekka.png",
                "wall_breaker.png",
                "wizard.png"
            ];
        private static readonly List<string> buildingImagePaths =
            [
                "air_defense.png",
                "archer_tower.png",
                "army_camp.png",
                "cannon.png",
                "clan_castle.png",
                "dark_elixir_drill.png",
                "elixir_collector.png",
                "gold_mine.png",
                "inferno_tower.png",
                "laboratory.png",
                "town_hall.png",
                "wizard_tower.png",
                "x_bow.png"
            ];
        public enum BuildingIndexes
        {
            AirDefense = 0,
            ArcherTower = 1,
            ArmyCamp = 2,
            Cannon = 3,
            ClanCastle = 4,
            DarkElixirDrill = 5,
            ElixirCollector = 6,
            GoldMine = 7,
            InfernoTower = 8,
            Laboratory = 9,
            TownHall = 10,
            WizardTower = 11,
            XBow = 12
        }
        public enum TroopIndexes
        {
            Archer = 0,
            Balloon = 1,
            Barbarian = 2,
            Dragon = 3,
            Giant = 4,
            Goblin = 5,
            Healer = 6,
            Pekka = 7,
            WallBreaker = 8,
            Wizard = 9
        }

        private static readonly ImmutableDictionary<string, BuildingIndexes> DatabaseToBuildingIndexDictionary = ImmutableDictionary.CreateRange(
                new KeyValuePair<string, BuildingIndexes>[]
                {
                    KeyValuePair.Create("Difesa aerea", BuildingIndexes.AirDefense),
                    KeyValuePair.Create("Torre dell'arciere", BuildingIndexes.ArcherTower),
                    KeyValuePair.Create("Accampamento", BuildingIndexes.ArmyCamp),
                    KeyValuePair.Create("Cannone", BuildingIndexes.Cannon),
                    KeyValuePair.Create("Castello del clan", BuildingIndexes.ClanCastle),
                    KeyValuePair.Create("Trivella per elisir nero", BuildingIndexes.DarkElixirDrill),
                    KeyValuePair.Create("Estrattore di elisir", BuildingIndexes.ElixirCollector),
                    KeyValuePair.Create("Miniera d'oro", BuildingIndexes.GoldMine),
                    KeyValuePair.Create("Torre infernale", BuildingIndexes.InfernoTower),
                    KeyValuePair.Create("Laboratorio", BuildingIndexes.Laboratory),
                    KeyValuePair.Create("Municipio", BuildingIndexes.TownHall),
                    KeyValuePair.Create("Torre dello stregone", BuildingIndexes.WizardTower),
                    KeyValuePair.Create("Arco-X", BuildingIndexes.XBow)
                }
            );
        private static readonly ImmutableDictionary<string, TroopIndexes> DatabaseToTroopIndexDictionary = ImmutableDictionary.CreateRange(
                new KeyValuePair<string, TroopIndexes>[]
                {
                    KeyValuePair.Create("Arciere", TroopIndexes.Archer),
                    KeyValuePair.Create("Mongolfiera", TroopIndexes.Balloon),
                    KeyValuePair.Create("Barbaro", TroopIndexes.Barbarian),
                    KeyValuePair.Create("Drago", TroopIndexes.Dragon),
                    KeyValuePair.Create("Gigante", TroopIndexes.Giant),
                    KeyValuePair.Create("Goblin", TroopIndexes.Goblin),
                    KeyValuePair.Create("Guaritore", TroopIndexes.Healer),
                    KeyValuePair.Create("Pekka", TroopIndexes.Pekka),
                    KeyValuePair.Create("Spaccamuro", TroopIndexes.WallBreaker),
                    KeyValuePair.Create("Stregone", TroopIndexes.Wizard)
                }
            );

        public static string GetPath(string imageName)
        {
            return $"{basePath}.{imageName}";
        }
        public static Image BackArrow()
        {
            return GetImageFromResources("back_arrow.png");
        }

        private static Image GetImageFromResources(string imageName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = GetPath(imageName);

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new ArgumentException($"Resource '{resourceName}' not found.");
                }
                return Image.FromStream(stream);
            }
        }

        public static ImageList GetTroopsImageList(Size size)
        {
            var imageList = new ImageList
            {
                ImageSize = size
            };
            foreach (var imageName in troopImagePaths)
            {
                imageList.Images.Add(GetImageFromResources($"{troopPath}.{imageName}"));
            }
            return imageList;
        }

        public static ImageList GetBuildingsImageList(Size size)
        {
            var imageList = new ImageList
            {
                ImageSize = size
            };
            foreach (var imageName in buildingImagePaths)
            {
                imageList.Images.Add(GetImageFromResources($"{buildingPath}.{imageName}"));
            }
            return imageList;
        }

        public static ImageList GetBuildingsAndTroopsImageList(Size size)
        {
            var imageList = new ImageList
            {
                ImageSize = size
            };
            foreach (var imageName in buildingImagePaths)
            {
                imageList.Images.Add(GetImageFromResources($"{buildingPath}.{imageName}"));
            }
            foreach (var imageName in troopImagePaths)
            {
                imageList.Images.Add(GetImageFromResources($"{troopPath}.{imageName}"));
            }
            return imageList;
        }

        public static BuildingIndexes GetIndexFromDatabaseBuildingName(string buildingName) => DatabaseToBuildingIndexDictionary[buildingName];
        public static TroopIndexes GetIndexFromDatabaseTroopName(string troopName) => DatabaseToTroopIndexDictionary[troopName];
    }
}
