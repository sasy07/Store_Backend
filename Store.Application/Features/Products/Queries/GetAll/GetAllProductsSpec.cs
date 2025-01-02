using Store.Application.Contracts.Specification;
using Store.Domain.Entities;

namespace Store.Application.Features.Products.Queries.GetAll;

public class GetAllProductsSpec : BaseSpecification<Product>
{
    public GetAllProductsSpec():base()
    {
        AddInclude(x=>x.ProductBrand);
        AddInclude(x=>x.ProductType);
    }

    public GetAllProductsSpec(int id):base(x=>x.Id == id)
    {
        AddInclude(x => x.ProductBrand);
        AddInclude(x => x.ProductType);
    }
}