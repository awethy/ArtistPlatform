namespace ArtistPlatform.Application.Common.Pagination
{
    public class PagedResult<T>
    {
        public IReadOnlyCollection<T> Items { get; set; } = [];
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    }
}
