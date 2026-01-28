using AMLRS.Core.Abstraction.Reposotory;
using AMLRS.Core.Domains.Documents.Entities;
using AMLRS.Infrastructure.Data;

namespace AMLRS.Infrastructure.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly AmlDbContext _context;

        public DocumentRepository(AmlDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Document document)
        {
            _context.Documents.Add(document);
            await _context.SaveChangesAsync();
        }
    }

}
