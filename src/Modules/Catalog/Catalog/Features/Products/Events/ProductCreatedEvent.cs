namespace Catalog.Features.Products.Events;

public record ProductCreatedEvent(Product Product) : DomainEvent;