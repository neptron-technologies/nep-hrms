using nep_hrms.DAL.Interfaces;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.DAL.Repositories
{
    public class DocumentRepo: BaseRepo<Document>, IDocumentRepo
    {
        private readonly IBaseRepo<Document> _baseRepo;
        private readonly HrmsDBContext _dbContext;
        public DocumentRepo(HrmsDBContext context, IBaseRepo<Document> baseRepo) : base(context)
        {
            _baseRepo = baseRepo;
            _dbContext = context;
        }
    }
}
