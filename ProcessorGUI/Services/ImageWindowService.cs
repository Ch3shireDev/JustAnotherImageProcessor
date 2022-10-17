using System;
using ProcessorGUI.ViewModels;
using ProcessorGUI.Views;
using ProcessorLibrary;

namespace ProcessorGUI.Services;

public class ImageWindowService : IImageWindowService
{
    public ImageData CurrentImage { get; private set; }

    public void OpenImageWindow(ImageData imageData)
    {
        var bitmap = imageData.Bitmap;
        var size = bitmap.Size;
        var width = size.Width;
        var height = size.Height;
        var title = $"{imageData.Filename} ({width}x{height})";
        var imageViewModel = new ImageViewModel(imageData, this)
        {
            Image = bitmap
        };

        var imageWindow = new ImageWindow
        {
            DataContext = imageViewModel,
            Title = title
        };

        imageWindow.Show();
    }

    public void SelectImage(ImageData imageData)
    {
        CurrentImage = imageData;
        ImageSelected?.Invoke(this, imageData);
    }

    public event EventHandler<ImageData>? ImageSelected;
}