namespace FlightSchoolTss.Data.Interfaces.Generic;

public interface IAnonymousRepository<TEntity> where TEntity : class
{
    Task<IList<TEntity>> GetAllAsync();
    Task<TEntity> GetAsync(int? id);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(int id);
    Task<bool> DeleteAsync(int id);
}