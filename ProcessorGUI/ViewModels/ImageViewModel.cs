using System.Windows.Input;
using ProcessorLibrary.Models;
using ReactiveUI;
using ABitmap = Avalonia.Media.Imaging.Bitmap;

namespace ProcessorGUI.ViewModels
{
    public class ImageViewModel : ReactiveObject
    {
        private ABitmap image;


        public ImageViewModel(ImageModel imageModel)
        {
            ImageModel = imageModel;
        }
        public ABitmap Image
        {
            get => image;
            set
            {
                image = value;
                this.RaisePropertyChanged();
            }
        }

        public ImageModel ImageModel { get; set; }
        public ICommand CreateThresholdImageCommand => ReactiveCommand.Create(CreateThresholdImage);
        public ICommand ShowHistogramCommand => ReactiveCommand.Create(ShowHistogram);
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

        public void ShowHistogram()
        {
            ////var histogram = Tools.GetHistogram(Image);

            //double[] dataX = { 1, 2, 3, 4, 5 };
            //double[] dataY = { 1, 4, 9, 16, 25 };

            //var window = new PlotWindow();
            //window.Plot.AddScatter(dataX, dataY);
            //window.Show();
        }
    }
}