using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.DAL.Interfaces
{
    public interface IEmployeeRepo : IBaseRepo<Employee>
    {
       // Task<bool> UploadEmployeeDocument(int id, string documentName, string documentType, byte[] documentContent);

    }
}
