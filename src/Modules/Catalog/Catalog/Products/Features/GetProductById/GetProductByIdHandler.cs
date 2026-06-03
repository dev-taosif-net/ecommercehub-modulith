namespace Catalog.Products.Features.GetProductById;

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
public record GetProductByIdResult(ProductByIdDto ProductById);

internal class GetProductByIdHandler(CatalogDbContext dbContext)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await dbContext.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == query.Id, cancellationToken);

        if (product is null)
            throw new KeyNotFoundException($"ProductById with id '{query.Id}' was not found.");

        var productDto = product.Adapt<ProductByIdDto>();

        return new GetProductByIdResult(productDto);
    }
}

