using ProcessorGUI.ViewModels;
using ProcessorLibrary;
using ProcessorTests.Mockups;

namespace ProcessorTests;

[TestClass]
public class MainWindowViewModelTests
{
    /// <summary>
    ///     User should be able to open image in new window. After calling command, user is asked to select file paths, then
    ///     service loads images from file paths and shows them in new windows.
    /// </summary>
    [TestMethod]
    public void OpenImageTest()
    {
        var image = new BitmapData { Filename = "image.png" };

        var fileService = new MockFileService(new Dictionary<string, BitmapData> { { "image.png", image } });
        var fileSelectService = new MockFileSelectService("image.png");
        var imageWindowService = new MockImageWindowService();

        var viewModel = new MainWindowViewModel(fileService, fileSelectService, imageWindowService);

        Assert.AreEqual(false, fileSelectService.IsSelected);
        Assert.AreEqual(0, imageWindowService.OpenWindows.Count);
        viewModel.OpenImageWindowCommand.Execute(null);
        Assert.AreEqual(true, fileSelectService.IsSelected);
        Assert.AreEqual(1, imageWindowService.OpenWindows.Count);
        Assert.AreEqual(image, imageWindowService.OpenWindows[0]);
    }
}