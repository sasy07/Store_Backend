using System.Linq.Expressions;
using Store.Domain.Entities.Base;

namespace Store.Application.Contracts;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<T> AddAsync(T entity, CancellationToken cancellationToken);
    Task<T> UpdateAsync(T entity);
    Task Delete(T entity, CancellationToken cancellationToken);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
    Task<bool> AnyAsync(CancellationToken cancellationToken);
}