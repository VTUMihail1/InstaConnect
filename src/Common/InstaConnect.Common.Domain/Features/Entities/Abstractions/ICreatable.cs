namespace InstaConnect.Common.Domain.Features.Entities.Abstractions;

public interface ICreatable
{
	public DateTimeOffset CreatedAtUtc { get; }
}
