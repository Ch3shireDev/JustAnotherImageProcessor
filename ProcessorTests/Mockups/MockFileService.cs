using ProcessorLibrary.DataStructures;
using ProcessorLibrary.Services;

namespace ProcessorTests.Mockups;

public class MockFileService : IFileService
{
    public Dictionary<string, ImageData> Files { get; } = new Dictionary<string, ImageData>();
    public Dictionary<string, ImageData> SavedFiles { get; } = new Dictionary<string, ImageData>();

    public MockFileService(Dictionary<string, ImageData> files)
    {
        Files = files;
    }

    public MockFileService()
    {
        
    }

    public ImageData LoadBitmap(string filename)
    {
        return Files[filename];
    }

    public void SaveImage(string fileName, ImageData selectedImage)
    {
        SavedFiles.Add(fileName, selectedImage);
    }
}