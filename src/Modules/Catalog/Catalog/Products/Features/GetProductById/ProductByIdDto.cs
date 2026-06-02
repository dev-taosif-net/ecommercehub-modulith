namespace Catalog.Products.Features.GetProductById;

public record ProductByIdDto(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);

