namespace InstaConnect.Common.Domain.Features.Entities.Abstractions;

public interface IEntity
{
    public DateTimeOffset CreatedAtUtc { get; }
}
