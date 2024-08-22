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
    }
}
