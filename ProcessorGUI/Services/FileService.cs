using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using ProcessorGUI.ViewModels;
using ProcessorLibrary.DataStructures;
using ProcessorLibrary.Services;

namespace ProcessorGUI.Services
{
    public class FileService : IFileService
    {
        public ImageData LoadBitmap(string filename)
        {
            var bitmap = new Bitmap(filename);
            return new ImageData
            {
                Filename = filename,
                Bitmap = bitmap
            };
        }

        public void SaveImage(string fileName, ImageData selectedImage)
        {
            selectedImage.Bitmap.Save(fileName);
        }
    }
}