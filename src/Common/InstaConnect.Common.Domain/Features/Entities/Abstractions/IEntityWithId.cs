namespace InstaConnect.Common.Domain.Features.Entities.Abstractions;

public interface IEntityWithId<out TEntityId> : IEntity
	where TEntityId : IEntityId
{
	public TEntityId Id { get; }
}
