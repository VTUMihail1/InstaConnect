namespace InstaConnect.Common.Domain.Abstractions;

public interface IEntity<out TKey>
    where TKey : IEntityId
{
    public TKey Id { get; }
}
