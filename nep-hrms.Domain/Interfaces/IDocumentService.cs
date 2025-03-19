using System.Collections.Generic;
using System.Threading.Tasks;
using nep_hrms.Domain.Models;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.Domain.Interfaces
{
    public interface IDocumentService
    {
        Task<Document?> GetByIdAsync(int id); // Ensure nullable return type
        Task<List<Document>> GetAllAsync();
        Task<Document> AddAsync(Document document);
        Task UpdateAsync(Document document);
        Task DeleteAsync(int id);
    }
}
