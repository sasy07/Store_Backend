using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Store.Application.Contracts;
using Store.Application.Contracts.Specification;
using Store.Domain.Entities.Base;
using Store.Infrastructure.Persistence;

namespace Store.Infrastructure;

public class GenericRepository<T> : IGenericRepository<T>
    where T : BaseEntity
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }


    public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken)
        => await _dbSet.FirstOrDefaultAsync(x=>x.Id == id, cancellationToken);

    public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken)
        => await _dbSet.ToListAsync(cancellationToken);

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        return await Task.FromResult(entity);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return await Task.FromResult(entity);
    }

    public async Task Delete(T entity , CancellationToken cancellationToken)
    {
        var record = await GetByIdAsync(entity.Id , cancellationToken);
        record.IsDelete = true;
        await UpdateAsync(record);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        => await _dbSet.AnyAsync(expression, cancellationToken);

    public async Task<bool> AnyAsync(CancellationToken cancellationToken)
        => await _dbSet.AnyAsync(cancellationToken);

    public async Task<T> GetEntityWithSpec(ISpecification<T> spec, CancellationToken cancellationToken)
        => await ApplySpecification(spec).FirstOrDefaultAsync(cancellationToken);

    public async Task<IReadOnlyList<T>> ListAsyncSpec(ISpecification<T> spec, CancellationToken cancellationToken) 
        => await ApplySpecification(spec).ToListAsync(cancellationToken);

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        => SpecificationEvaluator<T>.GetQuery(_dbSet.AsQueryable(), spec);
}