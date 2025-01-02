using MediatR;
using Store.Domain.Entities;

namespace Store.Application.Features.Products.Queries.GetAll;

public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
{
    public int PageId { get; set; }
}