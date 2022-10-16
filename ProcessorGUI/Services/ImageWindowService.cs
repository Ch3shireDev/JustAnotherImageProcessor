using ProcessorGUI.ViewModels;
using ProcessorLibrary;

namespace ProcessorGUI.Services;

public class ImageWindowService : IImageWindowService
{
    public void ShowImage(BitmapData bitmapData)
    {
        var bitmap = bitmapData.Bitmap;
        var size = bitmap.Size;
        var width = size.Width;
        var height = size.Height;
        var title = $"{bitmapData.Filename} ({width}x{height})";
        Tools.OpenImageWindow(bitmap, title).Show();
    }
}