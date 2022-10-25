using System.Threading.Tasks;
using System.Windows.Input;
using ProcessorLibrary;
using ProcessorLibrary.DataStructures;
using ProcessorLibrary.Models;
using ProcessorLibrary.Services;
using ReactiveUI;

namespace ProcessorGUI.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    private readonly IFileSelectService? _fileSelectService;
    private readonly IFileService? _fileService;
    private readonly IImageWindowService? _imageWindowService;
    private readonly IHistogramService _histogramService;

    public MainWindowViewModel()
    {
    }

    public MainWindowViewModel(IFileService fileService, IFileSelectService fileSelectService,
        IImageWindowService imageWindowService, IHistogramService histogramService)
    {
        _fileService = fileService;
        _fileSelectService = fileSelectService;
        _imageWindowService = imageWindowService;
        _histogramService = histogramService;

        _imageWindowService.ImageSelected += (_, _) => { SelectedImage = _imageWindowService.CurrentImage; };
    }

    public ICommand OpenImageWindowCommand => ReactiveCommand.Create(OpenImageWindow);
    public ICommand CreateThresholdWindowCommand => ReactiveCommand.Create(CreateThresholdImageWindow);
    public ImageData SelectedImage { get; set; }
    public ICommand SaveImageCommand => ReactiveCommand.Create(SaveImage);
    public ICommand DuplicateImageCommand => ReactiveCommand.Create(DuplicateImage);

    private async Task SaveImage()
    {
        var fileName = await _fileSelectService.SelectFileToSave();
        _fileService.SaveImage(fileName, SelectedImage);
    }

    private void DuplicateImage()
    {
        var newImage = new ImageData(SelectedImage);
        var imageModel = new ImageModel(newImage, _fileService, _fileSelectService, _imageWindowService, _histogramService);
        _imageWindowService.OpenImageWindow(imageModel);
    }

    private void CreateThresholdImageWindow()
    {
    }

    private async Task OpenImageWindow()
    {
        var filePaths = await _fileSelectService.SelectFilesToOpen();
        if (filePaths == null) return;
        foreach (var filePath in filePaths)
        {
            var bitmap = _fileService.LoadBitmap(filePath);
            var imageModel = new ImageModel(bitmap, _fileService, _fileSelectService, _imageWindowService, _histogramService);
            _imageWindowService.OpenImageWindow(imageModel);
        }
    }
}