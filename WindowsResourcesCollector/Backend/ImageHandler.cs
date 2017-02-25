using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WindowsResourcesCollector.Backend
{
    internal static class ImageHandler
    {

        private static readonly Dictionary<string, string> AcceptedHeaders = new Dictionary<string, string>
        {
            {"FFD8", "jpg"},
            {"424D", "bmp"},
            {"474946", "gif"},
            {"89504E470D0A1A0A", "png"}
        };

        public static List<ResourceHandler> RetrieveImages(string path)=>!Directory.Exists(path) ? null : (Directory.GetFiles(path)).Where(IsImage).Select(file => new ResourceHandler(file)).ToList();

        public static bool IsImage(string path)
        {
            // open the file from the provided path
            using (var file = File.OpenRead(path) as Stream)
            {
                // start from the beginning of the file
                file.Seek(0, SeekOrigin.Begin);
                var build = new StringBuilder();

                // get the largest length of any header
                var largestHeaderValue = AcceptedHeaders.Max(ext => ext.Value.Length);

                // whilst all headers haven't been checked
                for (var i = 0; i < largestHeaderValue; i++)
                {
                    // read bit
                    var bit = file.ReadByte().ToString("X2");
                    // append bit to string builder
                    build.Append(bit);

                    var hexSearch = build.ToString();
                    var isImage = AcceptedHeaders.Keys.Any(hex => hex == hexSearch);
                    if (isImage)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
