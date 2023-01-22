using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Project_DAW.Data;
using Project_DAW.Models.Base;

namespace Project_DAW.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    { 
        protected readonly DataBaseContext _dataBaseContext;
        protected readonly DbSet<TEntity> _table;

        public GenericRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
            _table = _dataBaseContext.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _table.AsNoTracking().ToListAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
        }
        
        public void CreateRange(IEnumerable<TEntity> entities)
        {
            _table.AddRange(entities);
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await _table.AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }
        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _table.UpdateRange(entities);
        }

        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }
        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _table.RemoveRange(entities);
        }

        public TEntity? FindById(object id)
        {
            return _table.Find(id);
        }

        public async Task<TEntity> FindByIdAsync(object id)
        {
            return await _table.FindAsync(id);   
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _dataBaseContext.SaveChangesAsync() > 0;
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
