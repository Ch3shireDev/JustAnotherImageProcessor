using ProcessorLibrary.DataStructures;
using ProcessorLibrary.Models;
using ProcessorLibrary.Services;

namespace ProcessorTests.Mockups;

public class MockImageWindowService : IImageWindowService
{
    public List<ImageData> OpenWindows { get; } = new();

    public void OpenImageWindow(ImageModel imageData)
    {
        OpenWindows.Add(imageData.ImageData);
    }

    public void SelectImage(ImageData imageData)
    {
        CurrentImage = imageData;
        ImageSelected?.Invoke(this, imageData);
    }

    public event EventHandler<ImageData>? ImageSelected;

    public ImageData CurrentImage { get; private set; }
}