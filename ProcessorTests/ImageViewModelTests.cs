using ProcessorGUI.ViewModels;
using ProcessorLibrary;
using ProcessorTests.Mockups;

namespace ProcessorTests;

[TestClass]
public class ImageViewModelTests
{
    private MockImageWindowService? _imageWindowService;

    [TestInitialize]
    public void Initialize()
    {
        _imageWindowService = new MockImageWindowService();
    }

    [TestMethod]
    public void SelectImageTest()
    {
        var image = new ImageData();
        var viewModel = new ImageViewModel(image, _imageWindowService);
        viewModel.ActivatedCommand.Execute(null);
        Assert.AreEqual(image, _imageWindowService.CurrentImage);
    }
}