using FlightSchoolTss.Data.Data;
using FlightSchoolTss.Data.Interfaces.Generic;
using Microsoft.EntityFrameworkCore;

namespace FlightSchoolTss.Data.Repositories;
internal class AnonymousRepository<TEntity> : IAnonymousRepository<TEntity> where TEntity : class
{
    protected readonly FstssDataContext _context;
    private readonly DbSet<TEntity> _dbSet;
    public AnonymousRepository(FstssDataContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }
    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity is not null)
        {
            _dbSet.Remove(entity);
            return true;
        }
        return false;
    }
    public async Task<TEntity> GetAsync(int? id)
    {
        return await _dbSet.FindAsync(id);
    }
    public async Task<IList<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
    public async Task UpdateAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity is null)
            return;
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }
}
