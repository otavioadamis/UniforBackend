using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.Domain.Models.DTOs
{
    public class ListItemCardResponse
    {
        public IEnumerable<ItemCardDTO>? Items { get; set; }
        public int Pages { get; set; }
        public int PageAtual { get; set; }
    }
}
