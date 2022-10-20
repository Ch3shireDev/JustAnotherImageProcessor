using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using ProcessorLibrary.Services;

namespace ProcessorGUI.Services;

public class FileSelectService : IFileSelectService
{
    public async Task<string[]> SelectFilesToOpen()
    {
        var mainWindow = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
            ? desktop.MainWindow
            : null;
        var fileDialog = new OpenFileDialog
        {
            Title= "Open image",
            AllowMultiple = true
        };
        return await fileDialog.ShowAsync(mainWindow);
    }

    public async Task<string> SelectFileToSave()
    {
        var mainWindow = Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
            ? desktop.MainWindow
            : null;
        var fileDialog = new SaveFileDialog
        {
            Title = "Save Image",
            InitialFileName = "image.png"
        };
        
        return await fileDialog.ShowAsync(mainWindow) ?? "";
    }
}