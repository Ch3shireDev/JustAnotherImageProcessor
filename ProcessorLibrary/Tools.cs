using System.Drawing;
using ABitmap = Avalonia.Media.Imaging.Bitmap;
using MBitmap = System.Drawing.Bitmap;

namespace ProcessorLibrary
{
    public static class Tools
    {
        public static ABitmap MakeThresholdConvert(ABitmap image, double threshold)
        {
            var bitmap = image.ToM();
            var bitmap2 = MakeThresholdConvert(bitmap, threshold);
            return bitmap2.ToA();
        }

        public static MBitmap MakeThresholdConvert(MBitmap bitmap, double threshold)
        {
            for (var i = 0; i < bitmap.Width; i++)
                for (var j = 0; j < bitmap.Height; j++)
                {
                    var pixel = bitmap.GetPixel(i, j);
                    var brightness = pixel.GetBrightness();
                    if (brightness < threshold) bitmap.SetPixel(i, j, Color.Black);
                    else bitmap.SetPixel(i, j, Color.White);
                }

            var bitmap2 = bitmap;
            return bitmap2;
        }
        
        public static ABitmap Clone(this ABitmap bitmap)
        {
            using var memory = new MemoryStream();
            bitmap.Save(memory);
            memory.Position = 0;
            return new ABitmap(memory);
        }

        public static ABitmap ToA(this MBitmap bitmap)
        {
            using var memory2 = new MemoryStream();
            bitmap.Save(memory2, bitmap.RawFormat);
            memory2.Position = 0;
            return new ABitmap(memory2);
        }

        public static MBitmap ToM(this ABitmap bitmap)
        {
            using var memory2 = new MemoryStream();
            bitmap.Save(memory2);
            memory2.Position = 0;
            return new MBitmap(memory2);
        }

        //public static double[] GetAllHistograms(ABitmap image)
        //{

        //}
        public static void GetHistogram(ABitmap image)
        {
            var mimage = image.ToM();

            var redLUT = new int[sizeof(byte)];
            var greenLUT = new int[sizeof(byte)];
            var blueLUT = new int[sizeof(byte)];

            for (var x = 0; x < mimage.Width; x++)
                for (var y = 0; y < mimage.Height; y++)
                {
                    var pixel = mimage.GetPixel(x, y);
                    var red = pixel.R;
                    var green = pixel.G;
                    var blue = pixel.B;

                    redLUT[red]++;
                    greenLUT[green]++;
                    blueLUT[blue]++;
                }
        }
    }
}