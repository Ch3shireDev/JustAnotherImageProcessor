using ProcessorGUI.ViewModels;
using ProcessorLibrary.DataStructures;
using ProcessorLibrary.Models;
using ProcessorTests.Mockups;

namespace ProcessorTests;

[TestClass]
public class ImageViewModelTests
{
    private MockFileSelectService _fileSelectService;
    private MockFileService? _fileService;
    private MockHistogramService _histogramService;
    private MockImageWindowService? _imageWindowService;
    private ImageData image;
    private ImageModel model;
    private ImageViewModel viewModel;

    [TestInitialize]
    public void Initialize()
    {
        _imageWindowService = new MockImageWindowService();
        _fileService = new MockFileService();
        _fileSelectService = new MockFileSelectService();
        _histogramService = new MockHistogramService();
        image = new ImageData
        {
            Width = 100,
            Height = 200
        };
        
        model = new ImageModel(image, _fileService, _fileSelectService, _imageWindowService, _histogramService);
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

    [TestMethod]
    public void ShowHistogramTest()
    {
        viewModel.ShowAllHistogramsCommand.Execute(null);
        Assert.AreEqual(1, _imageWindowService.OpenWindows.Count);
    }

    [TestMethod]
    public void ShowScreenAdjustedWidthTest()
    {
        viewModel.ShowScreenAdjustedWidthCommand.Execute(null);
        Assert.AreEqual(ShowImageType.ScreenAdjusted, model.ShowImageType);
        //Assert.AreEqual(100, viewModel.DisplayImageWidth);
        Assert.Fail();
    }

    [TestMethod]
    public void ShowOriginalSizeTest()
    {
        viewModel.ShowOriginalSizeCommand.Execute(null);
        Assert.AreEqual(ShowImageType.OriginalSize, model.ShowImageType);
        Assert.AreEqual(100, viewModel.DisplayImageWidth);
    }

    [TestMethod]
    public void ShowScaledDown50PercentTest()
    {
        viewModel.ShowScaledDown50PercentCommand.Execute(null);
        Assert.AreEqual(ShowImageType.ScaledDown50Percent, model.ShowImageType);
        Assert.AreEqual(50, viewModel.DisplayImageWidth);
    }

    [TestMethod]
    public void ShowScaledDown25PercentTest()
    {
        viewModel.ShowScaledDown25PercentCommand.Execute(null);
        Assert.AreEqual(ShowImageType.ScaledDown25Percent, model.ShowImageType);
        Assert.AreEqual(25, viewModel.DisplayImageWidth);
    }

    [TestMethod]
    public void ShowScaledDown20PercentTest()
    {
        viewModel.ShowScaledDown20PercentCommand.Execute(null);
        Assert.AreEqual(ShowImageType.ScaledDown20Percent, model.ShowImageType);
        Assert.AreEqual(20, viewModel.DisplayImageWidth);
    }

    [TestMethod]
    public void ShowScaledDown10PercentTest()
    {
        viewModel.ShowScaledDown10PercentCommand.Execute(null);
        Assert.AreEqual(ShowImageType.ScaledDown10Percent, model.ShowImageType);
        Assert.AreEqual(10, viewModel.DisplayImageWidth);
    }

    [TestMethod]
    public void ShowScaledUp150PercentTest()
    {
        viewModel.ShowScaledUp150PercentCommand.Execute(null);
        Assert.AreEqual(ShowImageType.ScaledUp150Percent, model.ShowImageType);
        Assert.AreEqual(150, viewModel.DisplayImageWidth);
    }

    [TestMethod]
    public void ShowScaledUp200PercentTest()
    {
        viewModel.ShowScaledUp200PercentCommand.Execute(null);
        Assert.AreEqual(ShowImageType.ScaledUp200Percent, model.ShowImageType);
        Assert.AreEqual(200, viewModel.DisplayImageWidth);
    }
}