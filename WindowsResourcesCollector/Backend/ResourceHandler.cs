using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace WindowsResourcesCollector.Backend
{
    public class ResourceHandler
    {
        public string ImagePath { get; }

        public double Height { get; }

        public double Width { get; }

        public double ThumbHeight => Height*0.25;
        public double ThumbWidth => Width*0.25;
        public Orientation ImageOrientation { get; }

        public ImageFormat Type { get; }

        public ResourceHandler(string path)
        {
            ImagePath = path;

            using (var image = Image.FromFile(path))
            {
                Height = image.Height;
                Width = image.Width;

                ImageOrientation = (Math.Abs(Height - Width) < 0.5)
                    ? Orientation.Square
                    : (Height > Width) ? Orientation.Portrait : Orientation.Landscape;

                Type = image.RawFormat;

            }

        }
    }
}
