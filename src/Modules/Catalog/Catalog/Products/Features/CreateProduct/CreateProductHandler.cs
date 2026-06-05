using FluentValidation;

namespace Catalog.Products.Features.CreateProduct;

public record CreateProductCommand (CreateProductDto Product) :  ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Product.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Product.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(x => x.Product.ImageFile).NotEmpty().WithMessage("ImageFile is required");
        RuleFor(x => x.Product.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}

internal class CreateProductHandler(CatalogDbContext dbContext)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand createCommand, CancellationToken cancellationToken)
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