using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace AMLRS.Core.Domains.EntityProfiles.Entities
{
    public class AccountPurposeExpectedActivity
    {
        [Key]
        public string EntityId { get; set; }   // PK + FK
        public EntityProfile EntityProfile { get; set; }
        public string? PrimaryPurposeofAccount { get; set; }
        public string? IntendedProducts { get; set; }
        public string? ExpectedMonthlyDepositRange { get; set; }
        public string? ExpectedMonthlyWithdrawalRange { get; set; }
        public string? ExpectedMonthlyTransactionCount { get; set; }
        public string? ExpectedAverageTransactionValue { get; set; }
        public string? PrimaryIncomingPaymentType { get; set; }
        public string? PrimaryOutgoingPaymentType { get; set; }
        public string? ExpectedCountriesforIncomingTransfers { get; set; }
        public string? ExpectedCountriesforOutgoingTransfers { get; set; }
        public string? ExpectedUseofCash { get; set; }
        public string? ExpectedUseofCrypto_VirtualAssets { get; set; }
        public string? Notes_Rationale { get; set; }

    }
}
