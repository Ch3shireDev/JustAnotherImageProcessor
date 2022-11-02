using ProcessorLibrary.Services;

namespace ProcessorTests.Mockups;

public class MockScreenDimensions : IScreenDimensions
{
    public MockScreenDimensions(int screenWidth = 1920, int screenHeight = 1080)
    {
        ScreenWidth = screenWidth;
        ScreenHeight = screenHeight;
    }

    public int ScreenWidth { get; set; }
    public int ScreenHeight { get; set; }
}