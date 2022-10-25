using ProcessorLibrary.DataStructures;
using ProcessorLibrary.Services;

namespace ProcessorTests;

public class MockHistogramService : IHistogramService
{
    public ImageData GetAllHistograms(ImageData imageData)
    {
        return new ImageData(imageData);
    }

    public ImageData GetRedHistogram(ImageData imageData)
    {
        return new ImageData(imageData);
    }

    public ImageData GetGreenHistogram(ImageData imageData)
    {
        return new ImageData(imageData);
    }

    public ImageData GetBlueHistogram(ImageData imageData)
    {
        return new ImageData(imageData);
    }

    public ImageData GetIntensityHistogram(ImageData imageData)
    {
        return new ImageData(imageData);
    }
}