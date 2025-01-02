using MediatR;
using Store.Application.Contracts;
using Store.Domain.Entities;

namespace Store.Application.Features.Products.Queries.GetAll;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
{
    private readonly IUnitOfWork _uow;

    public GetAllProductsQueryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetAllProductsSpec();
        return await _uow.Repository<Product>().ListAsyncSpec(spec, cancellationToken);
    }
}