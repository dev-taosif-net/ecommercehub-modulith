namespace Catalog.Products.Domain.Events;

public record ProductPriceChangedEvent(Product Product): DomainEvent;