using AMLRS.Application.Interfaces.Services;
using AMLRS.Core.Domains.Documents.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMLRS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(
            string caseId,
            IFormFile file,
            [FromForm] DocumentType documentType)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is required.");

            await _documentService.UploadAsync(
                caseId,
                file,
                documentType,
                User.Identity!.Name!
            );

            return Ok();
        }
    }
}
