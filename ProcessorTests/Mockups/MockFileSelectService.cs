using ProcessorLibrary.Services;

namespace ProcessorTests.Mockups;

public class MockFileSelectService : IFileSelectService
{
    public List<string> FilesToOpen { get; } = new List<string>();
    public string FileToSave{ get; set; }
    public MockFileSelectService(){}

    public bool Executed { get; set; }

    public Task<string[]> SelectFilesToOpen()
    {
        Executed = true;
        return Task.FromResult(FilesToOpen.ToArray());
    }

    public Task<string> SelectFileToSave()
    {
        return Task.FromResult(FileToSave);
    }
}