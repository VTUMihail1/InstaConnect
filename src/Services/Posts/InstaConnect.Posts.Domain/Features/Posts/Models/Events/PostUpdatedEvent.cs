namespace InstaConnect.Posts.Domain.Features.Posts.Models.Events;

public record PostUpdatedEvent(
        string Id,
        string Title,
        string Content,
        string UserId,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
