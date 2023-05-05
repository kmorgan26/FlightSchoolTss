using Microsoft.EntityFrameworkCore;
using WebApiTraining.Data.Abstractions;
using WebApiTraining.Data.Data;
using WebApiTraining.Data.Interfaces;

namespace WebApiTraining.Data.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, IDisposable
{
    private readonly FstssDataContext _context;
    private readonly DbSet<TEntity> _dbSet;
    public GenericRepository(FstssDataContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }
    public async Task DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity is not null)
        {
            _dbSet.Remove(entity);
        }
    }
    public async Task<TEntity> GetAsync(int? id)
    {
        return await _dbSet.FindAsync(id);
    }
    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    public async Task<TEntity> UpdateAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null)
        {
            return entity;
        }
        _dbSet.Update(entity);
        return entity;
    }
    public async Task<bool> Exists(int id)
    {
        return await _dbSet.AnyAsync(e => e.Id == id);
    }
    public void Dispose()
    {
        _context.SaveChangesAsync().Dispose();
        GC.SuppressFinalize(this);
    }
}
