namespace Shared.DDD;

public interface IEntity<T> : IEntity
{
    T Id { get; }
}

public interface IEntity
{
    DateTime? CreatedAt { get; }
    string? CreatedBy { get; }
    DateTime? LastModifiedAt { get; }
    string? LastModifiedBy { get; }
}