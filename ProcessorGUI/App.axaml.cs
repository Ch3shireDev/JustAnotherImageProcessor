using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ProcessorGUI.Services;
using ProcessorGUI.ViewModels;
using ProcessorGUI.Views;
using ProcessorLibrary.Services;

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
            var lutService = new LutService();
            var histogramService = new HistogramService(lutService);

            var screenDimensions = new ScreenDimensions();

            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(fileService, fileSelectService, imageWindowService, histogramService, screenDimensions)
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}