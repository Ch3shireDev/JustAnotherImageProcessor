using ProcessorLibrary.DataStructures;
using ProcessorLibrary.Services;

namespace ProcessorLibrary
{
    public class ImageModel
    {
        public IFileSelectService _fileSelectService{ get; }
     public IFileService _fileService{ get; }
        public IHistogramService _histogramService{ get; }
       public IScreenDimensions _screenDimensions{ get; }
       public IImageWindowService _imageWindowService{ get; }
        public ImageData ImageData;
        
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