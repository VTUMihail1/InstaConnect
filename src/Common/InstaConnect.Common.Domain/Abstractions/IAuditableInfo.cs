namespace InstaConnect.Shared.Domain.Abstractions;

/// <summary>
/// Represents an interface for entities that track creation and update timestamps.
/// </summary>
public interface IAuditableInfo
{
    DateTime CreatedAt { get; }

    DateTime UpdatedAt { get; }
}
