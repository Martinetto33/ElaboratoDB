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
        public enum BuildingsIndexes
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
        public enum TroopsIndexes
        {
            Archer = 13,
            Balloon = 14,
            Barbarian = 15,
            Dragon = 16,
            Giant = 17,
            Goblin = 18,
            Healer = 19,
            Pekka = 20,
            WallBreaker = 21,
            Wizard = 22
        }

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
    }
}
