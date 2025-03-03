using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using nep_hrms.DAL.Interfaces;
using nep_hrms.Server.nep_hrms.DAL;

namespace nep_hrms.DAL.Repositories
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class

    {
        private readonly HrmsDBContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public BaseRepo(HrmsDBContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        //public async Task<IEnumerable<T>> GetAllAsync()
        //{
        //    var list = await _dbSet.ToListAsync();
        //    return list;
        //}

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();

        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        //public async Task<T> GetByIdAsync(string id)
        //{
        //    return await _dbSet.FindAsync(id);
        //}



        public async Task<T> GetUserAsync(string username)
        {
            return await _dbSet.FirstOrDefaultAsync();
        }


    }
}