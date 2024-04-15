namespace UniforBackend.Domain.Models.DTOs.PageTOs
{
    public class PagedResult<T>
    {
        public IEnumerable<T>? Items { get; set; }
        public int Pages { get; set; }
        public int PageAtual { get; set; }
    }
}
