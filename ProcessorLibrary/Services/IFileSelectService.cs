namespace ProcessorLibrary.Services;

public interface IFileSelectService
{
    Task<string[]> SelectFilesToOpen();
    Task<string> SelectFileToSave();
}