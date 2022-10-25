using System.Drawing;
using ProcessorLibrary.DataStructures;
using ScottPlot;
using Bitmap = Avalonia.Media.Imaging.Bitmap;

namespace ProcessorLibrary.Services;

public class HistogramService : IHistogramService
{
    private readonly ILutService _lutService;

    public HistogramService(ILutService lutService)
    {
        _lutService = lutService;
    }

    public ImageData GetAllHistograms(ImageData imageData)
    {
        var plot = new Plot(600, 400);
        GetHistogram(imageData, plot, x => _lutService.GetIntensityHistogram(x.Bytes), Color.Gray);
        GetHistogram(imageData, plot, x => _lutService.GetRedHistogram(x.Bytes), Color.Red);
        GetHistogram(imageData, plot, x => _lutService.GetGreenHistogram(x.Bytes), Color.Green);
        GetHistogram(imageData, plot, x => _lutService.GetBlueHistogram(x.Bytes), Color.Blue);

        plot.Title("All histograms");

        var bytes = plot.GetImageBytes();

        var image = new ImageData
        {
            Filename = "histogram.png",
            Bitmap = new Bitmap(new MemoryStream(bytes)),
            Bytes = bytes
        };

        return image;
    }

    public ImageData GetIntensityHistogram(ImageData imageData)
    {
        
        var plot = new Plot(600, 400);
        GetHistogram(imageData, plot, x => _lutService.GetIntensityHistogram(x.Bytes), Color.Gray, "Intensity");
        var bytes = plot.GetImageBytes();

        var image = new ImageData
        {
            Filename = "intensity histogram.png",
            Bitmap = new Bitmap(new MemoryStream(bytes)),
            Bytes = bytes
        };

        return image;
    }

    public ImageData GetRedHistogram(ImageData imageData)
    {
        var plot = new Plot(600, 400);
        GetHistogram(imageData, plot, x => _lutService.GetRedHistogram(x.Bytes), Color.Red, "Red");
        var bytes = plot.GetImageBytes();

        var image = new ImageData
        {
            Filename = "histogram red.png",
            Bitmap = new Bitmap(new MemoryStream(bytes)),
            Bytes = bytes
        };

        return image;
    }

    public ImageData GetGreenHistogram(ImageData imageData)
    {
        var plot = new Plot(600, 400);
        GetHistogram(imageData, plot, x => _lutService.GetGreenHistogram(x.Bytes),
            Color.Green, "Green");
        var bytes = plot.GetImageBytes();

        var image = new ImageData
        {
            Filename = "histogram green.png",
            Bitmap = new Bitmap(new MemoryStream(bytes)),
            Bytes = bytes
        };

        return image;
    }

    public ImageData GetBlueHistogram(ImageData imageData)
    {
        var plot = new Plot(600, 400);
        GetHistogram(imageData, plot, x => _lutService.GetBlueHistogram(x.Bytes), Color.Blue, "Blue");
        var bytes = plot.GetImageBytes();

        var image = new ImageData
        {
            Filename = "histogram blue.png",
            Bitmap = new Bitmap(new MemoryStream(bytes)),
            Bytes = bytes
        };

        return image;
    }

    private void GetHistogram(ImageData imageData, Plot plot, Func<ImageData, int[]> func, Color color, string title="")
    {
        var dataX = Enumerable.Range(0, 256).Select(x => (double)x).ToArray();
        var dataY = func(imageData).Select(x => (double)x).ToArray();

        // display the histogram counts as a bar plot
        var bar = plot.AddBar(dataY, dataX, color);
        bar.BarWidth = 1;
        // customize the plot style
        plot.Title(title);
        plot.YAxis.Label("Count");
        plot.XAxis.Label("Pixel intensity");
        plot.SetAxisLimits(yMin: 0);
    }
}