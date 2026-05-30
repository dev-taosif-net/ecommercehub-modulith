namespace Catalog.Features.Products.Dtos;

public abstract record ProductDto(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);