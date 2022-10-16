using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ProcessorGUI.Services;
using ProcessorGUI.ViewModels;
using ProcessorGUI.Views;

namespace ProcessorGUI;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var fileService = new FileService();
            var fileSelectService = new FileSelectService();
            var imageWindowService = new ImageWindowService();

            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(fileService, fileSelectService, imageWindowService)
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}