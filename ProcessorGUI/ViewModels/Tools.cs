using System.Drawing;
using System.IO;
using ProcessorGUI.Views;
using ABitmap = Avalonia.Media.Imaging.Bitmap;
using MBitmap = System.Drawing.Bitmap;

namespace ProcessorGUI.ViewModels;

public static class Tools
{
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

    public static ImageWindow OpenImageWindow(ABitmap bitmap, string title)
    {
        var imageViewModel = new ImageViewModel
        {
            Image = bitmap
        };

        var imageWindow = new ImageWindow
        {
            DataContext = imageViewModel,
            Title = title
        };

        return imageWindow;
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
}