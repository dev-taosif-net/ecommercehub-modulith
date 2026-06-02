using MediatR;


namespace Catalog.Features.Products.Domain.EventHandlers;

internal sealed class ProductPriceChangedEventHandler(ILogger<ProductPriceChangedEventHandler> logger)
    : INotificationHandler<ProductPriceChangedEvent>
{
    public Task Handle(ProductPriceChangedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Domain event handled: {EventType} | ProductId: {ProductId} | Name: {ProductName} | NewPrice: {NewPrice} | OccurredOn: {OccurredOn}",
            notification.EventType,
            notification.Product.Id,
            notification.Product.Name,
            notification.Product.Price,
            notification.OccurredOn);

        return Task.CompletedTask;
    }
}