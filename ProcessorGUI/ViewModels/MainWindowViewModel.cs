using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media.Imaging;
using ReactiveUI;

namespace ProcessorGUI.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ICommand OpenImageWindowCommand => ReactiveCommand.Create(OpenImageWindow);
    public ICommand CreateThresholdWindowCommand => ReactiveCommand.Create(CreateThresholdImageWindow);

    private void CreateThresholdImageWindow()
    {
    }

    private async Task OpenImageWindow()
    {
        var mainWindow = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
            ? desktop.MainWindow
            : null;
        var fileDialog = new OpenFileDialog
        {
            AllowMultiple = true
        };
        var filePaths = await fileDialog.ShowAsync(mainWindow);
        if (filePaths == null) return;
        foreach (var filePath in filePaths)
        {
            var bitmap = new Bitmap(filePath);
            var size = bitmap.Size;
            var width = size.Width;
            var height = size.Height;
            var title = $"{filePath} ({width}x{height})";

            Tools.OpenImageWindow(bitmap, title).Show();
        }
    }
}