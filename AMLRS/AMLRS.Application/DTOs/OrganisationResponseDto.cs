using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMLRS.Application.DTOs
{
    public class OrganisationResponseDto
    {
        public int OrgId { get; init; }
        public string OrgLegalName { get; init; } = string.Empty;
        public DateTime CreatedOn { get; init; }
        public string PrimaryContactName { get; init; } = string.Empty;
        public string PrimaryContactEmail { get; init; } = string.Empty;

    }
}
