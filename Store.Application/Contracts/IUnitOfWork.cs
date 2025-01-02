using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities.Base;

namespace Store.Application.Contracts;

public interface IUnitOfWork
{
    DbContext Context { get; }
    Task<int> Save(CancellationToken cancellationToken);
    IGenericRepository<T> Repository<T>() where T : BaseEntity;
}