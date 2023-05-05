using System.Linq.Expressions;
using WebApiTraining.Data.Abstractions;

namespace WebApiTraining.Data.Interfaces;
public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> GetAsync(int? id);
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> AddAsync(TEntity entity);
    Task DeleteAsync(int id);
    Task<TEntity> UpdateAsync(int id);
    Task<bool> Exists(int id);
}
