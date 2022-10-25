using ProcessorLibrary.DataStructures;
using ProcessorLibrary.Services;

namespace ProcessorLibrary.Models;

public class ImageModel
{
    private readonly IFileSelectService _fileSelectService;
    private readonly IFileService _fileService;
    private readonly IHistogramService _histogramService;
    private readonly IImageWindowService _imageWindowService;
    public readonly ImageData ImageData;

    public ImageModel(ImageData imageData, IFileService fileService, IFileSelectService fileSelectService,
        IImageWindowService imageWindowService, IHistogramService histogramService)
    {
        ImageData = imageData;
        _fileService = fileService;
        _fileSelectService = fileSelectService;
        _imageWindowService = imageWindowService;
        _histogramService = histogramService;
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

    public void ShowAllHistograms()
    {
        var image = _histogramService.GetAllHistograms(ImageData);
        var imageModel =
            new ImageModel(image, _fileService, _fileSelectService, _imageWindowService, _histogramService);
        _imageWindowService.OpenImageWindow(imageModel);
    }

    public void ShowIntensityHistogram()
    {
        var image = _histogramService.GetIntensityHistogram(ImageData);
        var imageModel =
            new ImageModel(image, _fileService, _fileSelectService, _imageWindowService, _histogramService);
        _imageWindowService.OpenImageWindow(imageModel);
    }

    public void ShowRedHistogram()
    {
        var image = _histogramService.GetRedHistogram(ImageData);
        var imageModel =
            new ImageModel(image, _fileService, _fileSelectService, _imageWindowService, _histogramService);
        _imageWindowService.OpenImageWindow(imageModel);
    }

    public void ShowBlueHistogram()
    {
        var image = _histogramService.GetBlueHistogram(ImageData);
        var imageModel =
            new ImageModel(image, _fileService, _fileSelectService, _imageWindowService, _histogramService);
        _imageWindowService.OpenImageWindow(imageModel);
    }

    public void ShowGreenHistogram()
    {
        var image = _histogramService.GetGreenHistogram(ImageData);
        var imageModel =
            new ImageModel(image, _fileService, _fileSelectService, _imageWindowService, _histogramService);
        _imageWindowService.OpenImageWindow(imageModel);
    }
}