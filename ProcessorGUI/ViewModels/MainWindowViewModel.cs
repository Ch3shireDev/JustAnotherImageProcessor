using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media.Imaging;
using ProcessorGUI.Views;
using ReactiveUI;

namespace ProcessorGUI.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ICommand OpenImageWindowCommand => ReactiveCommand.Create(OpenImageWindow);

    private async Task OpenImageWindow()
    {
        var mainWindow = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
            ? desktop.MainWindow
            : null;
        var fileDialog = new OpenFileDialog();
        fileDialog.AllowMultiple = true;
        var filePaths = await fileDialog.ShowAsync(mainWindow);
        if (filePaths == null) return;
        foreach(var filePath in filePaths)
        {
            var bitmap = new Bitmap(filePath);
            var imageViewModel = new ImageViewModel
            {
                Image = bitmap
            };

            var imageWindow = new ImageWindow { DataContext = imageViewModel };
            imageWindow.Show();
        }
    }
}