using Microsoft.AspNetCore.Mvc;
using nep_hrms.Domain.Interfaces;
using nep_hrms.Server.nep_hrms.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace nep_hrms.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<ActionResult<List<Document>>> GetAllDocuments()
        {
            var documents = await _documentService.GetAllAsync();
            return Ok(documents);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Document>> GetDocumentById(int id)
        {
            var document = await _documentService.GetByIdAsync(id);
            if (document == null)
                return NotFound("Document not found.");

            return Ok(document);
        }

        [HttpPost]
        [Route("upload")]
        public async Task<ActionResult<Document>> UploadDocument([FromForm] DocumentUploadDto documentDto)
        {
            if (documentDto.File == null || documentDto.File.Length == 0)
                return BadRequest("Invalid file upload.");

            using var memoryStream = new MemoryStream();
            await documentDto.File.CopyToAsync(memoryStream);
            var fileBytes = memoryStream.ToArray();

            var document = new Document
            {
                Content = fileBytes,
                Type = documentDto.Type,
                Description = documentDto.Description,
                CreatedBy = documentDto.CreatedBy,
                CreatedDt = DateTime.UtcNow
            };

            var createdDocument = await _documentService.AddAsync(document);
            return CreatedAtAction(nameof(GetDocumentById), new { id = createdDocument.Id }, createdDocument);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument(int id, [FromBody] Document document)
        {
            var existingDocument = await _documentService.GetByIdAsync(id);
            if (existingDocument == null)
                return NotFound("Document not found.");

            existingDocument.Description = document.Description;
            existingDocument.Type = document.Type;
            existingDocument.UpdatedBy = document.UpdatedBy;
            existingDocument.UpdatedDt = DateTime.UtcNow;

            await _documentService.UpdateAsync(existingDocument);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            var existingDocument = await _documentService.GetByIdAsync(id);
            if (existingDocument == null)
                return NotFound("Document not found.");

            await _documentService.DeleteAsync(id);
            return NoContent();
        }

    
        [HttpGet]
        [Route("download/{id}")]
        public async Task<IActionResult> DownloadDocument(int id)
        {
            var document = await _documentService.GetByIdAsync(id);
            if (document == null || document.Content == null)
                return NotFound("Document not found.");

            return File(document.Content, "application/octet-stream", $"document_{id}.{document.Type}");
        }
    }

    public class DocumentUploadDto
    {
        public IFormFile File { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
    }
}
