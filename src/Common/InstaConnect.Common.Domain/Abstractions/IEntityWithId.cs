namespace InstaConnect.Common.Domain.Abstractions;

public interface IEntityWithId<out TKey> : IEntity
    where TKey : IEntityId
{
    public TKey Id { get; }
}
