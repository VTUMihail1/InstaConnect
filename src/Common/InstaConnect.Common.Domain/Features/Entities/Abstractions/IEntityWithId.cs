namespace InstaConnect.Common.Domain.Features.Entities.Abstractions;

public interface IEntityWithId<out TKey> : IEntity
    where TKey : IEntityId
{
    public TKey Id { get; }
}
