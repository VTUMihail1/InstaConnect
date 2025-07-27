namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Events;

public record PostLikeAddedEvent(
        string Id,
        string PostId,
        string UserId,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
