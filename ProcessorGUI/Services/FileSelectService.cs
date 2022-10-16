using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using ProcessorLibrary;

namespace ProcessorGUI.Services;

public class FileSelectService : IFileSelectService
{
    public async Task<string[]> SelectFiles()
    {
        var mainWindow = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
            ? desktop.MainWindow
            : null;
        var fileDialog = new OpenFileDialog
        {
            AllowMultiple = true
        };
        return await fileDialog.ShowAsync(mainWindow);
    }
}