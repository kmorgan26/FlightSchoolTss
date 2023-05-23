using FlightSchoolTss.Data.Abstractions;
using FlightSchoolTss.Data.Data;
using Microsoft.EntityFrameworkCore;
using FlightSchoolTss.Data.Interfaces.Generic;

namespace FlightSchoolTss.Data.Repositories;
public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly FstssDataContext _context;
    private readonly DbSet<TEntity> _dbSet;
    public GenericRepository(FstssDataContext context)
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

        if(entity is null)
            return;
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }
    public async Task<bool> Exists(int id)
    {
        return await _dbSet.AnyAsync(e => e.Id == id);
    }
}