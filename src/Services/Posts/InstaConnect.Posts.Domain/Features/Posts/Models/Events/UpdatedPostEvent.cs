namespace InstaConnect.Posts.Domain.Features.Posts.Models.Events;

public record UpdatedPostEvent(
        string id,
        string title,
        string content,
        string userId,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt);
