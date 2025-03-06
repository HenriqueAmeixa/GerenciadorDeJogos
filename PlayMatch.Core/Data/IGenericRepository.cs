
namespace PlayMatch.Core.Data
{
    public interface IGenericRepository<T> where T : new()
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<int> DeleteAsync<T>(int id) where T : new();
    }
}
