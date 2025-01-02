using MediatR;
using Store.Domain.Entities;

namespace Store.Application.Features.ProductBrands.Queries.GetAll
{
    public class GetAllProductBrandQuery : IRequest<IEnumerable<ProductBrand>>
    {
    }
}
