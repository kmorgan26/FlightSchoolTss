namespace FlightSchoolCm.UI.Interfaces;

public interface IGenericApiClient<TEntity> : IDisposable
{
    Task<List<TEntity>?> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    Task CreateAsync(TEntity dto);
    Task UpdateAsync(int? id, TEntity dto);
    Task DeleteAsync(int id);
}