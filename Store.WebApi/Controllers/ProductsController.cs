using Microsoft.AspNetCore.Mvc;
using Store.Application.Features.Products.Queries.Get;
using Store.Application.Features.Products.Queries.GetAll;
using Store.Domain.Entities;
using Store.WebApi.Common;

namespace Store.WebApi.Controllers;

public class ProductsController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await Mediator.Send(new GetAllProductsQuery(), cancellationToken));

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> Get([FromRoute] int id, CancellationToken cancellationToken)
        => Ok(await Mediator.Send(new GetProductQuery(id), cancellationToken));
}