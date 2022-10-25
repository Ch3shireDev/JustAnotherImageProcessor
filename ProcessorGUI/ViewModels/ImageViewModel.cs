using System.Windows.Input;
using ProcessorGUI.Views;
using ProcessorLibrary.Models;
using ReactiveUI;
using ABitmap = Avalonia.Media.Imaging.Bitmap;

namespace ProcessorGUI.ViewModels
{
    public class ImageViewModel : ReactiveObject
    {

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
}