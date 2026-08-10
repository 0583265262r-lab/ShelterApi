namespace EmergencyShelterReadinessSystemAPI.Dto
{
    public class PagedResultDto <T>
    {
        public IEnumerable<T> Item { get; set; }
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }
}
