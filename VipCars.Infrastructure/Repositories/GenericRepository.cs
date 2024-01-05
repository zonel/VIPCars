using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VipCars.Domain.Repositories;
using VipCars.Infrastructure.Persistence;

namespace VipCars.Infrastructure.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly VipDbContext _context;
    private readonly DbSet<TEntity> _entities;

    public GenericRepository(VipDbContext context)
    {
        _context = context;
        _entities = context.Set<TEntity>();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _entities.FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }

    public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _entities.Where(predicate).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _entities.Where(predicate).ToListAsync();
    }

    public async Task<int> AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        var property = _context.Entry(entity).Property("Id");
        return (int)(property.CurrentValue ?? throw new InvalidOperationException());
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _entities.AddRangeAsync(entities);
    }

    public void Remove(TEntity entity)
    {
        _entities.Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        _entities.RemoveRange(entities);
    }
}