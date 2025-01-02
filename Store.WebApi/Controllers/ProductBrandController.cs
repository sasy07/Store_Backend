using Microsoft.AspNetCore.Mvc;
using Store.Application.Features.ProductBrands.Queries.GetAll;
using Store.WebApi.Common;

namespace Store.WebApi.Controllers;

public class ProductBrandController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await Mediator.Send(new GetAllProductBrandQuery(), cancellationToken));
}