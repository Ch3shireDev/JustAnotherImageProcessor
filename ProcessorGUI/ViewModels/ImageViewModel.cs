using System.Windows.Input;
using ProcessorGUI.Views;
using ReactiveUI;
using ScottPlot;
using ABitmap = Avalonia.Media.Imaging.Bitmap;
using MBitmap = System.Drawing.Bitmap;

namespace ProcessorGUI.ViewModels;

public class ImageViewModel : ViewModelBase
{
    private ABitmap image;

    public ABitmap Image
    {
        get => image;
        set
        {
            image = value;
            this.RaisePropertyChanged();
        }
    }

    public ICommand CreateThresholdImageCommand => ReactiveCommand.Create(CreateThresholdImage);
    public ICommand ShowHistogramCommand => ReactiveCommand.Create(ShowHistogram);

    private void CreateThresholdImage()
    {
        var thresholdViewModel = new ThresholdViewModel();

        var slider = new ThresholdWindow
        {
            DataContext = thresholdViewModel
        };

        var imageViewModel = new ImageViewModel();

        thresholdViewModel.ThresholdChanged += (a, b) =>
        {
            imageViewModel.Image =
                Tools.MakeThresholdConvert(Image, thresholdViewModel.Threshold / thresholdViewModel.MaxValue);
        };

        thresholdViewModel.Refresh();

        slider.Show();

        var imageWindow = new ImageWindow
        {
            DataContext = imageViewModel,
            Title = "clone"
        };

        imageWindow.Show();
    }

    public void ShowHistogram()
    {
        //var histogram = Tools.GetHistogram(Image);

        double[] dataX = { 1, 2, 3, 4, 5 };
        double[] dataY = { 1, 4, 9, 16, 25 };
        
        var window = new PlotWindow();
        window.Plot.AddScatter(dataX, dataY);
        window.Show();
    }
}