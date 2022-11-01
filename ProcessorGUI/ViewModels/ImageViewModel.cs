using System.Windows.Input;
using ProcessorLibrary.Models;
using ReactiveUI;
using ABitmap = Avalonia.Media.Imaging.Bitmap;

namespace ProcessorGUI.ViewModels;

public class ImageViewModel : ReactiveObject
{
    private int _displayImageWidth = 400;

    public ImageViewModel(ImageModel imageModel)
    {
        ImageModel = imageModel;
    }

    public ABitmap Image => ImageModel.ImageData.Bitmap;
    public ImageModel ImageModel { get; set; }
    public ICommand CreateThresholdImageCommand => ReactiveCommand.Create(CreateThresholdImage);
    public ICommand ShowAllHistogramsCommand => ReactiveCommand.Create(ImageModel.ShowAllHistograms);
    public ICommand ShowIntensityHistogramCommand => ReactiveCommand.Create(ImageModel.ShowIntensityHistogram);
    public ICommand ShowRedHistogramCommand => ReactiveCommand.Create(ImageModel.ShowRedHistogram);
    public ICommand ShowGreenHistogramCommand => ReactiveCommand.Create(ImageModel.ShowGreenHistogram);
    public ICommand ShowBlueHistogramCommand => ReactiveCommand.Create(ImageModel.ShowBlueHistogram);
    public ICommand ActivatedCommand => ReactiveCommand.Create(ImageModel.Activate);
    public ICommand SaveImageCommand => ReactiveCommand.Create(ImageModel.SaveImage);
    public ICommand ShowScreenAdjustedWidthCommand => ReactiveCommand.Create(ShowScreenAdjustedWidth);
    public ICommand ShowOriginalSizeCommand => ReactiveCommand.Create(ShowOriginalSize);
    public ICommand ShowScaledDown50PercentCommand => ReactiveCommand.Create(ShowScaledDown50Percent);

    public ICommand ShowScaledDown25PercentCommand => ReactiveCommand.Create(ShowScaledDown25Percent);

    public ICommand ShowScaledDown20PercentCommand => ReactiveCommand.Create(ShowScaledDown20Percent);

    public ICommand ShowScaledDown10PercentCommand => ReactiveCommand.Create(ShowScaledDown10Percent);

    public ICommand ShowScaledUp150PercentCommand => ReactiveCommand.Create(ShowScaledUp150Percent);

    public ICommand ShowScaledUp200PercentCommand => ReactiveCommand.Create(ShowScaledUp200Percent);

    public int DisplayImageWidth
    {
        get => _displayImageWidth;
        set => this.RaiseAndSetIfChanged(ref _displayImageWidth, value);
    }

    private void ShowScaledDown50Percent()
    {
        ImageModel.ShowImageType = ShowImageType.ScaledDown50Percent;
        DisplayImageWidth = (int)(ImageModel.ImageData.Width * 0.5);
    }

    private void ShowScaledDown25Percent()
    {
        ImageModel.ShowImageType = ShowImageType.ScaledDown25Percent;
        DisplayImageWidth = (int)(ImageModel.ImageData.Width * 0.25);
    }

    private void ShowScaledDown20Percent()
    {
        ImageModel.ShowImageType = ShowImageType.ScaledDown20Percent;
        DisplayImageWidth = (int)(ImageModel.ImageData.Width * 0.2);
    }

    private void ShowScaledDown10Percent()
    {
        ImageModel.ShowImageType = ShowImageType.ScaledDown10Percent;
        DisplayImageWidth = (int)(ImageModel.ImageData.Width * 0.1);
    }

    private void ShowScaledUp150Percent()
    {
        ImageModel.ShowImageType = ShowImageType.ScaledUp150Percent;
        DisplayImageWidth = (int)(ImageModel.ImageData.Width * 1.5);
    }


    private void ShowScaledUp200Percent()
    {
        ImageModel.ShowImageType = ShowImageType.ScaledUp200Percent;
        DisplayImageWidth = (int)(ImageModel.ImageData.Width * 2);
    }

    private void ShowOriginalSize()
    {
        ImageModel.ShowImageType = ShowImageType.OriginalSize;
        DisplayImageWidth = ImageModel.ImageData.Width;
    }

    private void ShowScreenAdjustedWidth()
    {
        ImageModel.ShowImageType = ShowImageType.ScreenAdjusted;
        DisplayImageWidth = (int)(ImageModel.ImageData.Width * 0.5);
    }

    private void CreateThresholdImage()
    {
        //var thresholdViewModel = new ThresholdViewModel();

        //var slider = new ThresholdWindow
        //{
        //    DataContext = thresholdViewModel
        //};

        //var imageData = new ImageData();

        //var imageViewModel = new ImageViewModel(imageData, _fileService, _fileSelectService, _imageWindowService);

        //thresholdViewModel.ThresholdChanged += (a, b) =>
        //{
        //    imageViewModel.Image =
        //        Tools.MakeThresholdConvert(Image, thresholdViewModel.Threshold / thresholdViewModel.MaxValue);
        //};

        //thresholdViewModel.Refresh();

        //slider.Show();

        //var imageWindow = new ImageWindow
        //{
        //    DataContext = imageViewModel,
        //    Title = "clone"
        //};

        //imageWindow.Show();
    }
}