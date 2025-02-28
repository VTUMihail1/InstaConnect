namespace InstaConnect.Common.Domain.Abstractions;

/// <summary>
/// Represents an interface for entities that track creation and update timestamps.
/// </summary>
public interface IAuditableInfo
{
    DateTimeOffset CreatedAt { get; }

    DateTimeOffset UpdatedAt { get; }
}
