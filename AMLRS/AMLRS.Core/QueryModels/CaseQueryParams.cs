namespace AMLRS.Core.QueryModels
{
    public class CaseQueryParams
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;


        public string? SearchText { get; set; }
        //public CaseStatus? Status { get; set; }
        //public RiskLevel? Risk { get; set; }
        //public string? Owner { get; set; }
    }

}
