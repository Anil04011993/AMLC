using AMLRS.Core.Domains.Documents.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Core.Abstraction.Reposotory
{
    public interface IDocumentRepository
    {
        Task AddAsync(Document document);
    }

}
