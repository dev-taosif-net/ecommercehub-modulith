using FluentValidation;

namespace Catalog.Products.Features.UpdateProduct;

public record UpdateProductCommand(UpdateProductDto Product)
    : ICommand<UpdateProductResult>;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Product.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Product.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Product.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(x => x.Product.ImageFile).NotEmpty().WithMessage("ImageFile is required");
        RuleFor(x => x.Product.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}

public record UpdateProductResult(bool IsSuccess);

internal class UpdateProductHandler(CatalogDbContext dbContext)
    : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await dbContext.Products
            .FindAsync([command.Product.Id], cancellationToken: cancellationToken);

        if (product is null)
        {
            // throw new ProductNotFoundException(command.ProductById.Id);
            throw new Exception($"ProductById with id {command.Product.Id} not found.");
        }

        UpdateProductWithNewValues(product, command.Product);

        dbContext.Products.Update(product);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateProductResult(true);
    }

    private static void UpdateProductWithNewValues(Product product, UpdateProductDto dto)
    {
        product.Update(
            dto.Name,
            dto.Category,
            dto.Description,
            dto.ImageFile,
            dto.Price);
    }
}