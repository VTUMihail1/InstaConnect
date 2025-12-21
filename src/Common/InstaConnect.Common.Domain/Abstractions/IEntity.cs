namespace InstaConnect.Common.Domain.Abstractions;

public interface IEntity
{
    public DateTimeOffset CreatedAtUtc { get; }
}
