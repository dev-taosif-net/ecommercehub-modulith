namespace Catalog.Products.Features.CreateProduct;

public record CreateProductDto(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price);
