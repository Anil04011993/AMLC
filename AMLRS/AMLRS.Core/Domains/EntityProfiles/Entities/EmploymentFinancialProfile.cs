using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Core.Domains.EntityProfiles.Entities
{
    public class EmploymentFinancialProfile
    {
        [Key]
        public string EntityId { get; set; }   // PK + FK
        public EntityProfile EntityProfile { get; set; }
        public string? EmploymentStatus { get; set; }
        public string? EmploymentType { get; set; }
        public string? Occupation { get; set; }
        public string? EmployerName { get; set; }
        public string? EmployerIndustry { get; set; }
        public string? WorkAddress { get; set; }
        public string? AnnualIncomeRange { get; set; }
        public string? MonthlyNetIncomeRange { get; set; }
        public string? EstimatedNetWorthRange { get; set; }
        public string? SourceofFunds { get; set; }
        public string? SourceofWealth { get; set; }
        public string? ExpectedSourceofIncomingFunds { get; set; }
        public string? CashIntensiveBusinessExposure { get; set; }
        public string? HighRiskIndustryExposure { get; set; }
    }
}
