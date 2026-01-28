using AMLRS.Core.Domains.Documents.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.Interfaces.Services
{
    public interface IDocumentService
    {
        Task UploadAsync(
            string caseId,
            IFormFile file,
            DocumentType documentType,
            string uploadedBy);
    }
}
