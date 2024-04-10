using BackOffice.Domain.Entities;

namespace BackOffice.Application.Common.Interfaces;

public interface IRepository<T> where T : class
{
    public Task<List<T>> GetAllAsync();
    public Task<T> GetByIdAsync(string id);
    public Task CreateAsync(T entity);
    public Task UpdateAsync(string id, T entity);
    public Task RemoveAsync(string id);
}
