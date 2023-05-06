using System.Linq.Expressions;
using WebApiTraining.Data.Abstractions;

namespace WebApiTraining.Data.Interfaces;
public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetAsync(int? id);
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(int id);
    Task<bool> DeleteAsync(int id);
    Task<bool> Exists(int id);
}
