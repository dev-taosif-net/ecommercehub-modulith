namespace Catalog.Features.Products.Domain.Events;

public record ProductPriceChangedEvent(Product Product): DomainEvent;