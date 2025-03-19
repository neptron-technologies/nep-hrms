using nep_hrms.DAL.Interfaces;
using nep_hrms.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.Domain.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepo _documentRepo;

        public DocumentService(IDocumentRepo documentRepo)
        {
            _documentRepo = documentRepo;
        }

        public async Task<Document?> GetByIdAsync(int id) // Ensure nullable return type
        {
            return await _documentRepo.GetByIdAsync(id);
        }

        public async Task<List<Document>> GetAllAsync()
        {
            return await _documentRepo.GetAllAsync();
        }

        public async Task<Document> AddAsync(Document document)
        {
            return await _documentRepo.AddAsync(document);
        }

        public async Task UpdateAsync(Document document)
        {
            await _documentRepo.UpdateAsync(document);
        }

        public async Task DeleteAsync(int id)
        {
            await _documentRepo.DeleteAsync(id);
        }
    }
}
