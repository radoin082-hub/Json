namespace BlazorApp1.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public byte[] ImageData { get; set; } // Store image as byte array

        public string ImageBase64 => ImageData != null ? $"data:image/jpeg;base64,{Convert.ToBase64String(ImageData)}" : null;
    }
}