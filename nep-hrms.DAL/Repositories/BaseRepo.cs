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
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _dbContext.Set<T>();
        }
     
        public async Task<List<T>> GetAllAsync()  //all emp
        {
            return await _dbSet.ToListAsync();

        }

        public async Task<T> GetByIdAsync(int id) //emp by id
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)  //add
        {
            var addedEntity = await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return addedEntity.Entity;
        }

        public async Task UpdateAsync(T entity) //update
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
            //return msg
        }

        public async Task DeleteAsync(int id) //delete
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        // get all for IQuerable 
        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public async Task<List<T>> GetDataBySql(string sqlQry)  //sql query to find specific id
        {
            return await _dbContext.Database.SqlQueryRaw<T>(sqlQry).ToListAsync();
            //return await _dbContext.Database.SqlQuery<T>(sqlQry);
        }
    }
}