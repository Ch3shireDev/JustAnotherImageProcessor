
using ProcessorGUI.Views;
using ReactiveUI;

using System.Drawing;
using System.Windows.Input;
using ABitmap = Avalonia.Media.Imaging.Bitmap;

namespace ProcessorGUI.ViewModels;

public class ImageViewModel : ViewModelBase
{
    public ABitmap Image { get; set; }
    public ICommand CreateThresholdImageCommand => ReactiveCommand.Create(CreateThresholdImage);

    private void CreateThresholdImage()
    {
        //var slider = new ThresholdWindow();
        //slider.Show();

        var bitmap = Image.ToM();

        var threshold = 0.5;

        var bitmap2 = Tools.MakeThresholdConvert(bitmap, threshold);

        var image2 = bitmap2.ToA();

        var imageViewModel = new ImageViewModel
        {
            Image = image2
        };

        var imageWindow = new ImageWindow
        {
            DataContext = imageViewModel,
            Title = "clone"
        };
        imageWindow.Show();
    }

}