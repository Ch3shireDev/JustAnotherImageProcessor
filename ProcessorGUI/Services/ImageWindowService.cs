using System;
using ProcessorGUI.Models;
using ProcessorGUI.ViewModels;
using ProcessorGUI.Views;
using ProcessorLibrary.DataStructures;
using ProcessorLibrary.Services;

namespace ProcessorGUI.Services;

public class ImageWindowService : IImageWindowService
{
    public ImageData CurrentImage { get; private set; }

    public void OpenImageWindow(ImageModel imageModel)
    {
        var bitmap = imageModel.ImageData.Bitmap;
        var size = bitmap.Size;
        var width = size.Width;
        var height = size.Height;
        var title = $"{imageModel.ImageData.Filename} ({width}x{height})";
        
        var imageViewModel = new ImageViewModel(imageModel);

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