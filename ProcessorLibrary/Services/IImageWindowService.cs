using ProcessorLibrary.DataStructures;
using ProcessorLibrary.Models;

namespace ProcessorLibrary.Services
{
    public interface IImageWindowService
    {
        ImageData CurrentImage { get; }
        void OpenImageWindow(ImageModel imageData);
        void SelectImage(ImageData imageData);

        event EventHandler<ImageData> ImageSelected;
    }
}