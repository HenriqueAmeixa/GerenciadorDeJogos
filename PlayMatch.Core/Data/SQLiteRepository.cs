
using SQLite;

namespace PlayMatch.Core.Data
{
    public class SQLiteRepository<T> : IGenericRepository<T> where T : new()
    {
        private readonly SQLiteAsyncConnection _database;

        public SQLiteRepository(PlayMatchDbContext dbContext)
        {
            _database = dbContext.Database;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _database.Table<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _database.FindAsync<T>(id);
        }

        public async Task<int> InsertAsync(T entity)
        {
            return await _database.InsertAsync(entity);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            return await _database.UpdateAsync(entity);
        }

        public async Task<int> DeleteAsync(T entity)
        {
            return await _database.DeleteAsync(entity);
        }
    }
}
