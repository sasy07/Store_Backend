using Microsoft.AspNetCore.Mvc;
using Store.Application.Features.ProductTypes.Queries.GetAll;
using Store.WebApi.Common;

namespace Store.WebApi.Controllers;

public class ProductTypeController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken cancellationToken)
        => Ok(await Mediator.Send(new GetAllProductTypeQuery(), cancellationToken));
}