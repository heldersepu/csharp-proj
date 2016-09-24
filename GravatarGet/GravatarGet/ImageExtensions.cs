using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace GravatarGet
{
    public static class ImageExtensions
    {
        public static Image CropImage(this Image sourceImage, int width, int height, int x, int y)
        {
            var destinationImage = new Bitmap(width, height);
            destinationImage.SetPixel(0, 0, Color.White);
            destinationImage.SetResolution(sourceImage.HorizontalResolution, sourceImage.VerticalResolution);

            using (var graphicsSurface = Graphics.FromImage(destinationImage))
            {
                Rectangle ImageSize = new Rectangle(0, 0, width, height);
                graphicsSurface.FillRectangle(Brushes.White, ImageSize);
                graphicsSurface.DrawImage(sourceImage, -x, -y);
            }

            return destinationImage;
        }

        public static Image ResizeImage(this Image sourceImage, int width, int height)
        {
            var destinationRectangle = new Rectangle(0, 0, width, height);
            var destinationImage = new Bitmap(width, height);
            destinationImage.SetResolution(sourceImage.HorizontalResolution, sourceImage.VerticalResolution);

            using (var graphicsSurface = Graphics.FromImage(destinationImage))
            {
                // Various settings to ensure quality is not lost in the resizing.
                graphicsSurface.CompositingMode = CompositingMode.SourceCopy;
                graphicsSurface.CompositingQuality = CompositingQuality.HighQuality;
                graphicsSurface.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsSurface.SmoothingMode = SmoothingMode.HighQuality;
                graphicsSurface.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphicsSurface.DrawImage(sourceImage, destinationRectangle, 0, 0, sourceImage.Width, sourceImage.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destinationImage;
        }
    }
}
