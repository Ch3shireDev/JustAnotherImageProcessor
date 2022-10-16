namespace ProcessorLibrary;

public interface IFileSelectService
{
    Task<string[]> SelectFiles();
}