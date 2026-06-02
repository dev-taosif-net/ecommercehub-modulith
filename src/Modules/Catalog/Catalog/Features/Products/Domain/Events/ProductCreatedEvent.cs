namespace Catalog.Features.Products.Domain.Events;

public record ProductCreatedEvent(Product Product) : DomainEvent;