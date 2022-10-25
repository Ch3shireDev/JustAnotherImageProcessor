using System.IO;
using Avalonia.Media.Imaging;
using ProcessorLibrary.DataStructures;
using ProcessorLibrary.Services;

namespace ProcessorGUI.Services;

public class FileService : IFileService
{
    public ImageData LoadBitmap(string filename)
    {
        var bytes = File.ReadAllBytes(filename);
        var bitmap = new Bitmap(new MemoryStream(bytes));
        
        return new ImageData
        {
            Filename = filename,
            Bitmap = bitmap,
            Bytes = bytes
        };
    }

    public void SaveImage(string fileName, ImageData selectedImage)
    {
        selectedImage.Bitmap.Save(fileName);
    }
}