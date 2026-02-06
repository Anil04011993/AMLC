namespace AMLRS.Core.QueryModels
{
    public class CaseQueryParams
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;        
        public string? SearchText { get; set; }
        public string ?Role { get; set; }
        public string? Organisation { get; set; }
    }

}
