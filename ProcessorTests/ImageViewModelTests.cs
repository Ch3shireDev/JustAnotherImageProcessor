using ProcessorGUI.ViewModels;
using ProcessorLibrary;
using ProcessorLibrary.DataStructures;
using ProcessorLibrary.Models;
using ProcessorTests.Mockups;

namespace ProcessorTests;

[TestClass]
public class ImageViewModelTests
{
    private MockFileSelectService _fileSelectService;
    private MockFileService? _fileService;
    private MockImageWindowService? _imageWindowService;
    private ImageData image;
    private ImageViewModel viewModel;

    [TestInitialize]
    public void Initialize()
    {
        _imageWindowService = new MockImageWindowService();
        _fileService = new MockFileService();
        _fileSelectService = new MockFileSelectService();
        image = new ImageData();
        var model = new ImageModel(image, _fileService, _fileSelectService, _imageWindowService);
        viewModel = new ImageViewModel(model);
    }

    [TestMethod]
    public void SelectImageTest()
    {
        viewModel.ActivatedCommand.Execute(null);
        Assert.AreEqual(image, _imageWindowService.CurrentImage);
    }

    [TestMethod]
    public void SaveImageTest()
    {
        _fileSelectService.FileToSave = "a.png";
        viewModel.SaveImageCommand.Execute(null);
        Assert.AreEqual(1, _fileService.SavedFiles.Count);
        CollectionAssert.AreEqual(new[] { "a.png" }, _fileService.SavedFiles.Keys);
        Assert.AreEqual(image, _fileService.SavedFiles["a.png"]);
    }
}