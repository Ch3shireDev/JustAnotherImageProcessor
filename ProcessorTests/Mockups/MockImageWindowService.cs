using ProcessorLibrary;

namespace ProcessorTests.Mockups;

public class MockImageWindowService : IImageWindowService
{
    public List<BitmapData> OpenWindows { get; } = new();

    public void ShowImage(BitmapData bitmapData)
    {
        OpenWindows.Add(bitmapData);
    }
}