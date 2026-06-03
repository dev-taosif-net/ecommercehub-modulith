namespace Catalog.Products.Features.CreateProduct;

public record CreateProductCreateCommand (CreateProductDto Product) :  ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

internal class CreateProductHandler(CatalogDbContext dbContext)
    : ICommandHandler<CreateProductCreateCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCreateCommand createCommand, CancellationToken cancellationToken)
    {
        var product = CreateNewProduct(createCommand.Product);

        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id);
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