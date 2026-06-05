namespace Catalog.Products.Features.CreateProduct;

public record CreateProductCreateRequest(CreateProductDto Product);

public record CreateProductResponse(Guid Id);

public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost(ProductEndpointGroup.Prefix, async (CreateProductCreateRequest createRequest, ISender sender) =>
        {
            var command = createRequest.Adapt<CreateProductCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateProductResponse>();
            return Results.Created($"/api/catalog/products/{response.Id}", response);
        })
        .WithName("CreateProduct")
        .Produces<CreateProductResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithTags(ProductEndpointGroup.Tag)
.WithSummary("Create Product")
.WithDescription("Create a new product");
    }
}