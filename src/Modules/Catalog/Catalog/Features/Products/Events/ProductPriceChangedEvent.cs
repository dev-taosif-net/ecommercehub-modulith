namespace Catalog.Features.Products.Events;

public record ProductPriceChangedEvent(Product Product): DomainEvent;