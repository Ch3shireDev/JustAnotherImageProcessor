using ProcessorLibrary;

namespace ProcessorTests.Mockups;

public class MockImageWindowService : IImageWindowService
{
    public List<ImageData> OpenWindows { get; } = new();

    public void OpenImageWindow(ImageData imageData)
    {
        OpenWindows.Add(imageData);
    }

    public void SelectImage(ImageData imageData)
    {
        CurrentImage = imageData;
        ImageSelected?.Invoke(this, imageData);
    }

    public event EventHandler<ImageData>? ImageSelected;

    public ImageData CurrentImage { get; private set; }
}