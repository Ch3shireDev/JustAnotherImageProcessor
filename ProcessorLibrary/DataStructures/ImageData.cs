using Avalonia.Media.Imaging;

namespace ProcessorLibrary.DataStructures
{
    public class ImageData
    {
        public ImageData() { }

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
    }
}