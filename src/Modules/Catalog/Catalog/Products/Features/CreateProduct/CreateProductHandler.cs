namespace Catalog.Products.Features.CreateProduct;

public record CreateProductCommand(CreateProductDto Product) : ICommand<CreateProductResponse>;

public record CreateProductResponse(Guid Id);

internal class CreateProductHandler(CatalogDbContext dbContext)
    : ICommandHandler<CreateProductCommand, CreateProductResponse>
{
    public async Task<CreateProductResponse> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = CreateNewProduct(command.Product);

        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateProductResponse(product.Id);
    }

    private static Product CreateNewProduct(CreateProductDto dto)
    {
        return Product.Create(
            Guid.NewGuid(),
            dto.Name,
            dto.Category,
            dto.Description,
            dto.ImageFile,
            dto.Price);
    }
}