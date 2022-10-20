using ProcessorGUI.ViewModels;
using ProcessorLibrary;
using ProcessorLibrary.DataStructures;
using ProcessorTests.Mockups;

namespace ProcessorTests;

[TestClass]
public class MainWindowViewModelTests
{
    private MockFileSelectService? _fileSelectService;
    private MockFileService? _fileService;
    private MockImageWindowService? _imageWindowService;
    private MainWindowViewModel? _viewModel;

    [TestInitialize]
    public void Initialize()
    {
        _fileService = new MockFileService();
        _fileSelectService = new MockFileSelectService();
        _imageWindowService = new MockImageWindowService();

        _viewModel = new MainWindowViewModel(_fileService, _fileSelectService, _imageWindowService);
    }

    /// <summary>
    ///     User should be able to open image in new window. After calling command, user is asked to select file paths, then
    ///     service loads images from file paths and shows them in new windows.
    /// </summary>
    [TestMethod]
    public void OpenImageTest()
    {
        var image = new ImageData { Filename = "image.png" };
        _fileService?.Files.Add("image.png", image);
        _fileSelectService?.FilesToOpen.Add("image.png");

        Assert.AreEqual(false, _fileSelectService?.Executed);
        Assert.AreEqual(0, _imageWindowService?.OpenWindows.Count);
        _viewModel?.OpenImageWindowCommand.Execute(null);
        Assert.AreEqual(true, _fileSelectService?.Executed);
        Assert.AreEqual(1, _imageWindowService?.OpenWindows.Count);
        Assert.AreEqual(image, _imageWindowService?.OpenWindows[0]);
    }

    /// <summary>
    ///     User should be able to access menu to currently selected image. Selected image should change automatically after
    ///     focusing other image.
    /// </summary>
    [TestMethod]
    public void SelectImageTest()
    {
        var image1 = new ImageData { Filename = "image1.png" };
        var image2 = new ImageData { Filename = "image2.png" };

        _fileService?.Files.Add("image1.png", image1);
        _fileService?.Files.Add("image2.png", image2);
        
        _fileSelectService?.FilesToOpen.Add("image1.png");
        _fileSelectService?.FilesToOpen.Add("image2.png");

        _viewModel?.OpenImageWindowCommand.Execute(null);

        Assert.AreEqual(2, _imageWindowService?.OpenWindows.Count);
        Assert.AreEqual(null, _viewModel?.SelectedImage);

        _imageWindowService?.SelectImage(image1);
        Assert.AreEqual(image1, _viewModel?.SelectedImage);

        _imageWindowService?.SelectImage(image2);
        Assert.AreEqual(image2, _viewModel?.SelectedImage);
    }

    /// <summary>
    ///     User should be able to save image to file. After calling command, user is asked to select file path, then service
    ///     saves given image at given path.
    /// </summary>
    [TestMethod]
    public void SaveImageTest()
    {
        var image1 = new ImageData { Filename = "image1.png" };
        
        _imageWindowService?.OpenWindows.Add(image1);

        _imageWindowService?.SelectImage(image1);

        _fileSelectService.FileToSave = "saved_image_1.png";

        _viewModel?.SaveImageCommand.Execute(null);

        Assert.AreEqual(1, _fileService?.SavedFiles.Count);
        Assert.AreEqual(image1, _fileService?.SavedFiles["saved_image_1.png"]);
    }

    /// <summary>
    /// User should be able to duplicate image. After calling command, new image is created with same content as selected.
    /// </summary>
    [TestMethod]
    public void DuplicateImageTest()
    {
        var image = new ImageData { Filename = "image1.png" };
        _imageWindowService?.OpenWindows.Add(image);
        _imageWindowService?.SelectImage(image);

        _viewModel?.DuplicateImageCommand.Execute(null);

        Assert.AreEqual(2, _imageWindowService.OpenWindows.Count);
        Assert.AreEqual(image, _imageWindowService.OpenWindows[0]);
        Assert.AreNotEqual(image, _imageWindowService.OpenWindows[1]);
    }
}