using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ProcessorGUI.Models;
using ReactiveUI;
using ABitmap = Avalonia.Media.Imaging.Bitmap;

namespace ProcessorGUI.ViewModels;

public class ImageViewModel : ReactiveObject, INotifyPropertyChanged
{
    private decimal _scale = 1M;

    public ImageViewModel()
    {
    }

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
    public ICommand ShowScreenAdjustedWidthCommand => ReactiveCommand.Create(ShowScreenAdjustedWidth);
    public ICommand ShowOriginalSizeCommand => ReactiveCommand.Create(ShowOriginalSize);
    public ICommand ShowScaledDown50PercentCommand => ReactiveCommand.Create(ShowScaledDown50Percent);
    public ICommand ShowScaledDown25PercentCommand => ReactiveCommand.Create(ShowScaledDown25Percent);
    public ICommand ShowScaledDown20PercentCommand => ReactiveCommand.Create(ShowScaledDown20Percent);
    public ICommand ShowScaledDown10PercentCommand => ReactiveCommand.Create(ShowScaledDown10Percent);
    public ICommand ShowScaledUp150PercentCommand => ReactiveCommand.Create(ShowScaledUp150Percent);
    public ICommand ShowScaledUp200PercentCommand => ReactiveCommand.Create(ShowScaledUp200Percent);
    public ICommand ActivatedCommand => ReactiveCommand.Create(ImageModel.Activate);
    public ICommand SaveImageCommand => ReactiveCommand.Create(ImageModel.SaveImage);
    public int MaxScreenWidth => ImageModel.ScreenWidth;
    public int MaxScreenHeight => ImageModel.ScreenHeight;

    public decimal Scale
    {
        get => _scale;
        set
        {
            _scale = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Width));
            OnPropertyChanged(nameof(Height));
            OnPropertyChanged(nameof(WindowWidth));
            OnPropertyChanged(nameof(WindowHeight));
        }
    }

    public int Width => (int)(ImageModel.ImageData.Width * Scale);
    public int Height => (int)(ImageModel.ImageData.Height * Scale);
    public int WindowWidth => Math.Min(Width, MaxScreenWidth);
    public int WindowHeight => Math.Min(Height, MaxScreenHeight);

    public new event PropertyChangedEventHandler? PropertyChanged;

    private void ShowScaledDown50Percent()
    {
        Scale *= 0.5m;
    }

    private void ShowScaledDown25Percent()
    {
        Scale *= 0.25m;
    }

    private void ShowScaledDown20Percent()
    {
        Scale *= 0.2m;
    }

    private void ShowScaledDown10Percent()
    {
        Scale *= 0.1m;
    }

    private void ShowScaledUp150Percent()
    {
        Scale *= 1.5m;
    }


    private void ShowScaledUp200Percent()
    {
        Scale *= 2m;
    }

    private void ShowOriginalSize()
    {
        Scale = 1M;
    }

    private void ShowScreenAdjustedWidth()
    {
        var factorX = (decimal)ImageModel.ImageData.Width / ImageModel.ScreenWidth;
        var factorY = (decimal)ImageModel.ImageData.Height / ImageModel.ScreenHeight;

        if (factorX < 1 && factorY < 1) return;

        if (factorX > factorY)
            Scale /= factorX;
        else
            Scale /= factorY;
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

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}