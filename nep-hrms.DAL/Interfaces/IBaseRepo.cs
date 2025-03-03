using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nep_hrms.DAL.Interfaces
{
    public interface IBaseRepo<T> where T : class
    {
        //public Task<IEnumerable<T>> GetAllAsync();
        public Task<List<T>> GetAllAsync();

        //public Task<List<T>> GetUserByName(string username);

        public Task<T> GetByIdAsync(int id);

        //public Task<T> GetUserAsync(string username);

        public Task AddAsync(T entity);

        public Task UpdateAsync(T entity);

        public Task DeleteAsync(int id);
    }
}
