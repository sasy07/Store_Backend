using MediatR;
using Store.Domain.Entities;

namespace Store.Application.Features.ProductTypes.Queries.GetAll
{
    public class GetAllProductTypeQuery : IRequest<IEnumerable<ProductType>>
    {
    }
}
