using System.Threading.Tasks;
using System.Windows.Input;
using ProcessorLibrary;
using ReactiveUI;

namespace ProcessorGUI.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly IFileSelectService? _fileSelectService;
    private readonly IFileService? _fileService;
    private readonly IImageWindowService? _imageWindowService;

    public MainWindowViewModel()
    {
    }

    public MainWindowViewModel(IFileService fileService, IFileSelectService fileSelectService,
        IImageWindowService imageWindowService)
    {
        _fileService = fileService;
        _fileSelectService = fileSelectService;
        _imageWindowService = imageWindowService;
    }

    public ICommand OpenImageWindowCommand => ReactiveCommand.Create(OpenImageWindow);
    public ICommand CreateThresholdWindowCommand => ReactiveCommand.Create(CreateThresholdImageWindow);

    private void CreateThresholdImageWindow()
    {
    }

    private async Task OpenImageWindow()
    {
        var filePaths = await _fileSelectService.SelectFiles();
        if (filePaths == null) return;
        foreach (var filePath in filePaths)
        {
            var bitmap = _fileService.LoadBitmap(filePath);
            _imageWindowService.ShowImage(bitmap);
        }
    }
}