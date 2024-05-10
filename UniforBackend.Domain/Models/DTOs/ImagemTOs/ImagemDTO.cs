using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Models.DTOs.ImageTOs
{
    public class ImagemDTO
    {
        public string Id { get; set; } = null!;
        public string URL { get; set; } = null!;
        public int Index { get; set; }

        public ImagemDTO()
        {
        }

        public ImagemDTO(string id, string ItemId, int index, string fileExt)
        {
            Id = id;
            Index = index;
            URL = "https://uniforbackend-test.s3.amazonaws.com/" + ItemId + "_" + index + fileExt;
        }
    }
}
