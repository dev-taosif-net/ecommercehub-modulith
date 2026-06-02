namespace Catalog.Products.Domain.Events;

public record ProductCreatedEvent(Product Product) : DomainEvent;