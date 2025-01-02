﻿using MediatR;
using Store.Application.Contracts;
using Store.Domain.Entities;

namespace Store.Application.Features.Products.Queries.Get;

public class GetProductQueryHandler:IRequestHandler<GetProductQuery , Product>
{
    private readonly IUnitOfWork _uow;

    public GetProductQueryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var entity = await _uow.Repository<Product>().GetByIdAsync(request.Id, cancellationToken);
        //TODO : Handle Exception 
        if (entity == null) throw new Exception("error ... ");
        return entity;
    }
}