namespace Catalog.Products.Features.GetProducts;

public record ProductDto(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);

