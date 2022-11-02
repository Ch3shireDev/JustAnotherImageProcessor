using Avalonia.Controls;
using Avalonia.Win32;
using ProcessorLibrary.Services;

namespace ProcessorGUI.Services;

public class ScreenDimensions : IScreenDimensions
{
    public ScreenDimensions()
    {
        var bounds = new Screens(new ScreenImpl()).Primary.Bounds;
        ScreenWidth = bounds.Width;
        ScreenHeight = bounds.Height;
    }

    public int ScreenWidth { get; }
    public int ScreenHeight { get; }
}