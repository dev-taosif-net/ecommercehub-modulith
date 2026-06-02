namespace Catalog.Products.Features.GetProductById;

public record ProductDto(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);

