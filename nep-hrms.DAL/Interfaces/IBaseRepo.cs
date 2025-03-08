using nep_hrms.Server.nep_hrms.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.DAL.Interfaces
{
    public interface IBaseRepo<T> where T : class
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<T> AddAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(int id);
        public Task<List<T>> GetDataBySql(string sqlQry);
    }
}