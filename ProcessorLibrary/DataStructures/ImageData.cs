using Avalonia.Media.Imaging;

namespace ProcessorLibrary.DataStructures;


public class ImageData
{
    private int height;
    private int width;

    public ImageData()
    {
    }
    
    public ImageData(ImageData imageData)
    {
        if (imageData == null) throw new Exception("Image data is null");
        Filename = imageData.Filename;

        if (imageData.Bitmap != null)
        {
            using var stream = new MemoryStream();
            imageData?.Bitmap?.Save(stream);
            stream.Position = 0;
            Bitmap = new Bitmap(stream);
            Bytes = stream.ToArray();
        }
    }

    public string Filename { get; set; }
    public Bitmap? Bitmap { get; set; }
    public byte[] Bytes { get; set; }

    public int Width
    {
        get => Bitmap?.PixelSize.Width ?? width;
        set => width = value;
    }

    public int Height
    {
        get => Bitmap?.PixelSize.Height ?? height;
        set => height = value;
    }
}