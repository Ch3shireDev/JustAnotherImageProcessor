namespace ProcessorLibrary;

public interface IImageWindowService
{
    void OpenImageWindow(ImageData imageData);
    void SelectImage(ImageData imageData);
    
    event EventHandler<ImageData> ImageSelected;
    ImageData CurrentImage { get; }
}