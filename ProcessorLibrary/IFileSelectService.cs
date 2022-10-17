namespace ProcessorLibrary;

public interface IFileSelectService
{
    Task<string[]> SelectFilesToOpen();
    Task<string> SelectFileToSave();
}