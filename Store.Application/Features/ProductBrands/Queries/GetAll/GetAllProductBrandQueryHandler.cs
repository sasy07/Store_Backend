using MediatR;
using Store.Application.Contracts;
using Store.Domain.Entities;

namespace Store.Application.Features.ProductBrands.Queries.GetAll;

public class GetAllProductBrandsQueryHandler : IRequestHandler<GetAllProductBrandQuery,IEnumerable<ProductBrand>>
{
    private readonly IUnitOfWork _uow;

    public GetAllProductBrandsQueryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IEnumerable<ProductBrand>> Handle(GetAllProductBrandQuery request,
        CancellationToken cancellationToken)
        => await _uow.Repository<ProductBrand>().GetAllAsync(cancellationToken);
}