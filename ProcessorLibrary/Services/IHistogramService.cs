using ProcessorLibrary.DataStructures;

namespace ProcessorLibrary.Services;

public interface IHistogramService
{
    ImageData GetAllHistograms(ImageData imageData);
    ImageData GetRedHistogram(ImageData imageData);
    ImageData GetGreenHistogram(ImageData imageData);
    ImageData GetBlueHistogram(ImageData imageData);
    ImageData GetIntensityHistogram(ImageData imageData);
}