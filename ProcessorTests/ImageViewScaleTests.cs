using ProcessorGUI.Models;
using ProcessorGUI.ViewModels;
using ProcessorLibrary.DataStructures;
using ProcessorTests.Mockups;
using ProcessorTests.Properties;

namespace ProcessorTests;

[TestClass]
public class ImageViewScaleTests
{
    private MockFileSelectService _fileSelectService;
    private MockFileService? _fileService;
    private MockHistogramService _histogramService;
    private MockImageWindowService? _imageWindowService;
    private MockScreenDimensions _screenDimensions;
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
        _screenDimensions = new MockScreenDimensions();

        var reference = Resources.black_100_200;
        using var stream = new MemoryStream();
        reference.Save(stream, reference.RawFormat);

        image = new ImageData
        {
            Height = 200,
            Width = 100,
            Filename = "test.png"
        };

        model = new ImageModel(image, _fileService, _fileSelectService, _imageWindowService, _histogramService,
            _screenDimensions);
        viewModel = new ImageViewModel(model);
    }

    
    /// <summary>
    ///     If the screen width is smaller than the image width, the image should be scaled down to fit the screen.
    /// </summary>
    [TestMethod]
    public void ShowScreenAdjustedWidthTest()
    {
        _screenDimensions.ScreenWidth = 1000;
        _screenDimensions.ScreenHeight = 1000;
        image.Width = 2000;
        image.Height = 1000;
        viewModel.ShowScreenAdjustedWidthCommand.Execute(null);
        //Assert.AreEqual(ShowImageType.ScreenAdjusted, model.ShowImageType);
        Assert.AreEqual(1000, viewModel.Width);
    }

    /// <summary>
    ///     If the width is ok but height is too big, the image should be scaled down to fit the screen.
    /// </summary>
    [TestMethod]
    public void ScaleDownHeightTest()
    {
        _screenDimensions.ScreenWidth = 1000;
        _screenDimensions.ScreenHeight = 1000;
        image.Width = 1000;
        image.Height = 2000;
        viewModel.ShowScreenAdjustedWidthCommand.Execute(null);
        Assert.AreEqual(0.5M, viewModel.Scale);
        //Assert.AreEqual(ShowImageType.ScreenAdjusted, model.ShowImageType);
        Assert.AreEqual(500, viewModel.Width);
    }

    /// <summary>
    ///     If both width and height are too big, the image should be scaled down to fit the screen.
    /// </summary>
    [TestMethod]
    public void ScaleBothTest()
    {
        _screenDimensions.ScreenWidth = 1000;
        _screenDimensions.ScreenHeight = 1000;
        image.Width = 2000;
        image.Height = 4000;
        viewModel.ShowScreenAdjustedWidthCommand.Execute(null);
        Assert.AreEqual(0.25M, viewModel.Scale);
        //Assert.AreEqual(ShowImageType.ScreenAdjusted, model.ShowImageType);
        Assert.AreEqual(500, viewModel.Width);
    }

    /// <summary>
    ///     If both width and height are too big, the image should be scaled down to fit the screen.
    /// </summary>
    [TestMethod]
    public void ScaleBothTest2()
    {
        _screenDimensions.ScreenWidth = 1000;
        _screenDimensions.ScreenHeight = 1000;
        image.Width = 4000;
        image.Height = 2000;
        viewModel.ShowScreenAdjustedWidthCommand.Execute(null);
        Assert.AreEqual(0.25M, viewModel.Scale);
        //Assert.AreEqual(ShowImageType.ScreenAdjusted, model.ShowImageType);
        Assert.AreEqual(1000, viewModel.Width);
    }

    [TestMethod]
    public void ShowOriginalSizeTest()
    {
        viewModel.ShowOriginalSizeCommand.Execute(null);
        Assert.AreEqual(1M, viewModel.Scale);
        //Assert.AreEqual(ShowImageType.OriginalSize, model.ShowImageType);
        Assert.AreEqual(100, viewModel.Width);
    }

    [TestMethod]
    public void ShowScaledDown50PercentTest()
    {
        viewModel.ShowScaledDown50PercentCommand.Execute(null);
        Assert.AreEqual(0.5M, viewModel.Scale);
        //Assert.AreEqual(ShowImageType.ScaledDown50Percent, model.ShowImageType);
        Assert.AreEqual(50, viewModel.Width);
    }

    [TestMethod]
    public void ShowScaledDown25PercentTest()
    {
        viewModel.ShowScaledDown25PercentCommand.Execute(null);
        Assert.AreEqual(0.25M, viewModel.Scale);
        //Assert.AreEqual(ShowImageType.ScaledDown25Percent, model.ShowImageType);
        Assert.AreEqual(25, viewModel.Width);
    }

    [TestMethod]
    public void ShowScaledDown20PercentTest()
    {
        viewModel.ShowScaledDown20PercentCommand.Execute(null);
        Assert.AreEqual(0.2M, viewModel.Scale);
        //Assert.AreEqual(ShowImageType.ScaledDown20Percent, model.ShowImageType);
        Assert.AreEqual(20, viewModel.Width);
    }

    [TestMethod]
    public void ShowScaledDown10PercentTest()
    {
        viewModel.ShowScaledDown10PercentCommand.Execute(null);
        Assert.AreEqual(0.1M, viewModel.Scale);
        //Assert.AreEqual(ShowImageType.ScaledDown10Percent, model.ShowImageType);
        Assert.AreEqual(10, viewModel.Width);
    }

    [TestMethod]
    public void ShowScaledUp150PercentTest()
    {
        viewModel.ShowScaledUp150PercentCommand.Execute(null);
        Assert.AreEqual(1.5M, viewModel.Scale);
        //Assert.AreEqual(ShowImageType.ScaledUp150Percent, model.ShowImageType);
        Assert.AreEqual(150, viewModel.Width);
    }

    [TestMethod]
    public void ShowScaledUp200PercentTest()
    {
        viewModel.ShowScaledUp200PercentCommand.Execute(null);
        Assert.AreEqual(2M, viewModel.Scale);

        //Assert.AreEqual(ShowImageType.ScaledUp200Percent, model.ShowImageType);
        Assert.AreEqual(200, viewModel.Width);
    }

    [TestMethod]
    public void ScaleTwiceTest()
    {
        viewModel.ShowScaledUp200PercentCommand.Execute(null);
        viewModel.ShowScaledUp200PercentCommand.Execute(null);
        Assert.AreEqual(4M, viewModel.Scale);
        //Assert.AreEqual(ShowImageType.ScaledUp200Percent, model.ShowImageType);
        Assert.AreEqual(400, viewModel.Width);
    }
}