using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ProcessorGUI.Models;
using ProcessorLibrary.DataStructures;
using ReactiveUI;
using ABitmap = Avalonia.Media.Imaging.Bitmap;

namespace ProcessorGUI.ViewModels;

public class ImageViewModel : ReactiveObject, INotifyPropertyChanged
{
    private int _displayImageWidth = 400;

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

    //public int DisplayImageWidth
    //{
    //    get => _displayImageWidth;
    //    set => this.RaiseAndSetIfChanged(ref _displayImageWidth, value);
    //}

    private decimal _scale = 1M;

    public decimal Scale
    {
        get => _scale;
        set
        {
            _scale = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Width));
            OnPropertyChanged(nameof(Height));
            //OnPropertyChanged(nameof(DisplayImageWidth));
        }
    }

    public int Width => (int)(ImageModel.ImageData.Width * Scale);
    public int Height => (int)(ImageModel.ImageData.Height * Scale);

    private void ShowScaledDown50Percent()
    {
        Scale *= 0.5m;
        //ImageModel.ShowImageType = ShowImageType.ScaledDown50Percent;
        //DisplayImageWidth = (int)(ImageModel.ImageData.Width * Scale);
    }

    private void ShowScaledDown25Percent()
    {
        Scale *= 0.25m;
        //ImageModel.ShowImageType = ShowImageType.ScaledDown25Percent;
        //DisplayImageWidth = (int)(ImageModel.ImageData.Width * Scale);
    }

    private void ShowScaledDown20Percent()
    {
        Scale *= 0.2m;
        //ImageModel.ShowImageType = ShowImageType.ScaledDown20Percent;
        //DisplayImageWidth = (int)(ImageModel.ImageData.Width * Scale);
    }

    private void ShowScaledDown10Percent()
    {
        Scale *= 0.1m;
        //ImageModel.ShowImageType = ShowImageType.ScaledDown10Percent;
        //DisplayImageWidth = (int)(ImageModel.ImageData.Width * Scale);
    }

    private void ShowScaledUp150Percent()
    {
        Scale *= 1.5m;
        //ImageModel.ShowImageType = ShowImageType.ScaledUp150Percent;
        //DisplayImageWidth = (int)(ImageModel.ImageData.Width * Scale);
    }


    private void ShowScaledUp200Percent()
    {
        Scale *= 2m;
        //ImageModel.ShowImageType = ShowImageType.ScaledUp200Percent;
        //DisplayImageWidth = (int)(ImageModel.ImageData.Width * Scale);
    }

    private void ShowOriginalSize()
    {
        Scale = 1M;
        //ImageModel.ShowImageType = ShowImageType.OriginalSize;
        //DisplayImageWidth = ImageModel.ImageData.Width;
    }

    private void ShowScreenAdjustedWidth()
    {
        
        //ImageModel.ShowImageType = ShowImageType.ScreenAdjusted;
        decimal factorX = (decimal)ImageModel.ImageData.Width /  ImageModel.ScreenWidth;
        decimal factorY =  (decimal)ImageModel.ImageData.Height /  ImageModel.ScreenHeight;

        if (factorX < 1 && factorY < 1) return;

        if (factorX > factorY)
        {
            Scale /= factorX;
            //DisplayImageWidth = (int)(ImageModel.ImageData.Width * Scale);
        }
        else
        {
            Scale /= factorY;
            //DisplayImageWidth = (int)(ImageModel.ImageData.Width * Scale);
        }

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

      public new event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
}