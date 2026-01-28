using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Core.Domains.Documents.Enums
{
    public enum DocumentType
    {
        IdCopy,
        AddressProof,
        RegistrationCertificate,
        Other
    }

    public enum DocumentStatus
    {
        Uploaded,
        InReview,
        Approved, 
        Rejected, 
        Expired
    }

}
