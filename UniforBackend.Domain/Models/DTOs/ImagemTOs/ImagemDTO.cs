namespace UniforBackend.Domain.Models.DTOs.ImageTOs
{
    public class ImagemDTO
    {
        public string Id { get; set; } = null!;
        public string URL { get; set; } = null!;
        public int Index { get; set; }

        public ImagemDTO() { }

        public ImagemDTO(string id, string ItemId, int index, string fileExt, string bucketName)
        {
            Id = id;
            Index = index;
            URL = $"https://{bucketName}.s3.amazonaws.com/" + ItemId + "_" + index + fileExt;
        }
    }
}
