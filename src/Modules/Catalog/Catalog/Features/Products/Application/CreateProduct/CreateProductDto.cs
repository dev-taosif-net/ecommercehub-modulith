namespace Catalog.Features.Products.Application.CreateProduct;

/// <summary>
/// Write model for creating a new product. Does not include Id — the domain generates it.
/// </summary>
public record CreateProductDto(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price);

