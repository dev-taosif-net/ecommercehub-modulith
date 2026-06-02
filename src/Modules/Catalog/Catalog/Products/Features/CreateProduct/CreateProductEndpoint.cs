namespace Catalog.Products.Features.CreateProduct;

public record CreateProductCreateRequest(CreateProductDto Product);

public record CreateProductResponse(Guid Id);

public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (CreateProductCreateRequest createRequest, ISender sender) =>
        {
            var command = createRequest.Adapt<CreateProductCreateCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateProductResponse>();
            return Results.Created($"/products/{response.Id}", response);
        });
    }
}