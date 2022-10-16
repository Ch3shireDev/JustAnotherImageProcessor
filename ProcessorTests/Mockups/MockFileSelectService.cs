using ProcessorLibrary;

namespace ProcessorTests.Mockups;

public class MockFileSelectService : IFileSelectService
{
    private readonly string[] _filenames;

    public MockFileSelectService(params string[] filenames)
    {
        _filenames = filenames;
    }

    public bool IsSelected { get; set; }

    public Task<string[]> SelectFiles()
    {
        IsSelected = true;
        return Task.FromResult(_filenames);
    }
}