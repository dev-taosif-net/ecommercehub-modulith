namespace Catalog.Products.Features.GetProductByCategory;

public record ProductByCategoryDto(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);

