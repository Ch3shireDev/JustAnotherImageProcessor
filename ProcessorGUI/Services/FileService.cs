using Avalonia.Media.Imaging;
using ProcessorGUI.ViewModels;
using ProcessorLibrary;

namespace ProcessorGUI.Services
{
    public class FileService : IFileService
    {
        public BitmapData LoadBitmap(string filename)
        {
            var bitmap = new Bitmap(filename);
            return new BitmapData
            {
                Filename = filename,
                Bitmap = bitmap
            };
        }
    }
}