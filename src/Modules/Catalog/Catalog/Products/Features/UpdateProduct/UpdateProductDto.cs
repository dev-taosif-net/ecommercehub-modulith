namespace Catalog.Products.Features.UpdateProduct;

/// <summary>
/// Write model for updating an existing product. Includes Id to identify the target record.
/// </summary>
public record UpdateProductDto(
    Guid Id,
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price);

