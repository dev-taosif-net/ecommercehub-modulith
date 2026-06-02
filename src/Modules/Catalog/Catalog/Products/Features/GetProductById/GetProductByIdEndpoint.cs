namespace Catalog.Products.Features.GetProductById;

public record GetProductByIdResponse(ProductByIdDto ProductById);

public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet($"{ProductEndpointGroup.Prefix}/{{id}}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));

                var response = result.Adapt<GetProductByIdResponse>();

                return Results.Ok(response);
            })
            .WithName("GetProductById")
            .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get ProductById By Id")
            .WithDescription("Get ProductById By Id");
    }
}