using ProcessorLibrary.DataStructures;

namespace ProcessorLibrary.Services;

public interface IFileService
{
    ImageData LoadBitmap(string filename);
    void SaveImage(string fileName, ImageData selectedImage);
}