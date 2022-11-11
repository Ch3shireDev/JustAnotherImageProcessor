using ProcessorGUI.ViewModels;
using ProcessorLibrary;
using ProcessorLibrary.DataStructures;
using ProcessorTests.Mockups;
using ProcessorTests.Properties;

namespace ProcessorTests
{
    [TestClass]
    public class ImageViewModelTests
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

    }
}