

using MediatR;

namespace Catalog.Features.Products.Application.CreateProduct;

public record CreateProductCommand(string Name) : ICommand<CreateProductResponse>;

public record CreateProductResponse(Guid Id);

public class CreateProductHandler
    (CatalogDbContext dbContext)
    : ICommandHandler<CreateProductCommand,CreateProductResponse>
{
    public Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}