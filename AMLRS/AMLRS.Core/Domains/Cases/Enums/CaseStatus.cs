using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Core.Domains.Cases.Enums
{
    public enum CaseStatus
    {
        New = 1,
        Assigned = 2,
        InProgress = 3,
        Escalated = 4,
        Submitted = 5,
        Approved = 6,
        Rejected = 7
    }

}
