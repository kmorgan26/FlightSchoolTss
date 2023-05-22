using System.Linq.Expressions;
using FlightSchoolTss.Data.Abstractions;

namespace FlightSchoolTss.Data.Interfaces;
public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    Task<IList<TEntity>> GetAllAsync();
    Task<TEntity> GetAsync(int? id);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(int id);
    Task<bool> DeleteAsync(int id);
    Task<bool> Exists(int id);
}