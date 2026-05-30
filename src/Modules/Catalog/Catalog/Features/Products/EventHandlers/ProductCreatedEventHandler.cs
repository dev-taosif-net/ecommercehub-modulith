using MediatR;

namespace Catalog.Features.Products.EventHandlers;

internal sealed class ProductCreatedEventHandler(ILogger<ProductCreatedEventHandler> logger)
    : INotificationHandler<ProductCreatedEvent>
{
    public Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Domain event handled: {EventType} | ProductId: {ProductId} | Name: {ProductName} | OccurredOn: {OccurredOn}",
            notification.EventType,
            notification.Product.Id,
            notification.Product.Name,
            notification.OccurredOn);

        return Task.CompletedTask;
    }
}


