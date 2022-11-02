using System.Threading.Tasks;
using ProcessorLibrary.DataStructures;
using ProcessorLibrary.Services;

namespace ProcessorGUI.Models
{

    public class ImageModel
    {
        private readonly IFileSelectService _fileSelectService;
        private readonly IFileService _fileService;
        private readonly IHistogramService _histogramService;
        private readonly IScreenDimensions _screenDimensions;
        private readonly IImageWindowService _imageWindowService;
        public readonly ImageData ImageData;
        
        public ImageModel(ImageData imageData, IFileService fileService, IFileSelectService fileSelectService,
            IImageWindowService imageWindowService, IHistogramService histogramService, IScreenDimensions screenDimensions)
        {
            ImageData = imageData;
            _fileService = fileService;
            _fileSelectService = fileSelectService;
            _imageWindowService = imageWindowService;
            _histogramService = histogramService;
            _screenDimensions = screenDimensions;
        }

        //public ShowImageType ShowImageType { get; set; }
        public int ScreenWidth => _screenDimensions.ScreenWidth;
        public int ScreenHeight => _screenDimensions.ScreenHeight;
        

        public async Task SaveImage()
        {
            var filename = await _fileSelectService.SelectFileToSave();
            _fileService.SaveImage(filename, ImageData);
        }

        public void Activate()
        {
            _imageWindowService.SelectImage(ImageData);
        }

        public void ShowAllHistograms()
        {
            var image = _histogramService.GetAllHistograms(ImageData);
            var imageModel =
                new ImageModel(image, _fileService, _fileSelectService, _imageWindowService, _histogramService, _screenDimensions);
            _imageWindowService.OpenImageWindow(imageModel);
        }

        public void ShowIntensityHistogram()
        {
            var image = _histogramService.GetIntensityHistogram(ImageData);
            var imageModel =
                new ImageModel(image, _fileService, _fileSelectService, _imageWindowService, _histogramService, _screenDimensions);
            _imageWindowService.OpenImageWindow(imageModel);
        }

        public void ShowRedHistogram()
        {
            var image = _histogramService.GetRedHistogram(ImageData);
            var imageModel =
                new ImageModel(image, _fileService, _fileSelectService, _imageWindowService, _histogramService, _screenDimensions);
            _imageWindowService.OpenImageWindow(imageModel);
        }

        public void ShowBlueHistogram()
        {
            var image = _histogramService.GetBlueHistogram(ImageData);
            var imageModel =
                new ImageModel(image, _fileService, _fileSelectService, _imageWindowService, _histogramService, _screenDimensions);
            _imageWindowService.OpenImageWindow(imageModel);
        }

        public void ShowGreenHistogram()
        {
            var image = _histogramService.GetGreenHistogram(ImageData);
            var imageModel =
                new ImageModel(image, _fileService, _fileSelectService, _imageWindowService, _histogramService, _screenDimensions);
            _imageWindowService.OpenImageWindow(imageModel);
        }
    }
}