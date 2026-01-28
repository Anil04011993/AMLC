using AMLRS.Application.Extentions;
using AMLRS.Application.Interfaces.Services;
using AMLRS.Application.Interfaces.Storage;
using AMLRS.Core.Abstraction.Reposotory;
using AMLRS.Core.Domains.Documents.Entities;
using AMLRS.Core.Domains.Documents.Enums;
using Microsoft.AspNetCore.Http;

namespace AMLRS.Application.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _repository;
        private readonly IFileStorage _storage;

        public DocumentService(
            IDocumentRepository repository,
            IFileStorage storage)
        {
            _repository = repository;
            _storage = storage;
        }

        public async Task UploadAsync(
            string caseId,
            IFormFile file,
            DocumentType documentType,
            string uploadedBy)
        {
            // 1️⃣ Validate MIME type
            if (!AllowedContentTypes.Contains(file.ContentType))
                throw new InvalidOperationException("Unsupported file type.");

            // 2️⃣ Compute hash
            string fileHash;
            using (var stream = file.OpenReadStream())
            {
                fileHash = HashHelper.ComputeSha256(stream);
            }

            // 3️⃣ Generate IDs
            var documentId = Guid.NewGuid().ToString();

            // 4️⃣ Storage path
            var storagePath =
                $"cases/{caseId}/documents/{documentId}/{file.FileName}";

            // 5️⃣ Save file
            await _storage.SaveAsync(storagePath, file);

            // 6️⃣ Persist metadata
            var document = new Document
            {
                DocumentId = documentId,
                CaseId = caseId,
                FileName = file.FileName,
                FilePath = storagePath,
                ContentType = file.ContentType,
                FileSize = file.Length,
                FileHash = fileHash,
                DocumentType = documentType,
                Status = DocumentStatus.Uploaded,
                Version = 1,
                IsLatest = true,
                UploadedBy = uploadedBy,
                UploadedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(document);
        }

        private static readonly HashSet<string> AllowedContentTypes =
            new()
            {
            "application/pdf",
            "image/jpeg",
            "image/png"
            };
    }

}
