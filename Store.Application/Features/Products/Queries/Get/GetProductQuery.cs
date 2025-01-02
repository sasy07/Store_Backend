using MediatR;
using Store.Domain.Entities;

namespace Store.Application.Features.Products.Queries.Get;

public class GetProductQuery:IRequest<Product>
{
    public int Id { get; set; }

    public GetProductQuery(int id)
    {
        Id = id;
    }
}