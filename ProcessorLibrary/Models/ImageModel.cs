using ProcessorLibrary.DataStructures;
using ProcessorLibrary.Services;

namespace ProcessorLibrary.Models
{
    public class ImageModel
    {
        private readonly IFileSelectService _fileSelectService;
        private readonly IFileService _fileService;
        private readonly IImageWindowService _imageWindowService;
        public readonly ImageData ImageData;

        public ImageModel(ImageData imageData, IFileService fileService, IFileSelectService fileSelectService,
            IImageWindowService imageWindowService)
        {
            ImageData = imageData;
            _fileService = fileService;
            _fileSelectService = fileSelectService;
            _imageWindowService = imageWindowService;
        }


        public async Task SaveImage()
        {
            var filename = await _fileSelectService.SelectFileToSave();
            _fileService.SaveImage(filename, ImageData);
        }

        public void Activate()
        {
            _imageWindowService.SelectImage(ImageData);
        }
    }
}