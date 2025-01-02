using MediatR;
using Store.Application.Contracts;
using Store.Application.Features.Products.Queries.GetAll;
using Store.Domain.Entities;

namespace Store.Application.Features.Products.Queries.Get;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
{
    private readonly IUnitOfWork _uow;

    public GetProductQueryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetAllProductsSpec();
        return await _uow.Repository<Product>().GetEntityWithSpec(spec, cancellationToken);
    }
}