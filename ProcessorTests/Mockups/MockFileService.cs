using ProcessorLibrary;

namespace ProcessorTests.Mockups;

public class MockFileService : IFileService
{
    private readonly Dictionary<string, BitmapData> _files;

    public MockFileService(Dictionary<string, BitmapData> files)
    {
        _files = files;
    }

    public BitmapData LoadBitmap(string filename)
    {
        return _files[filename];
    }
}