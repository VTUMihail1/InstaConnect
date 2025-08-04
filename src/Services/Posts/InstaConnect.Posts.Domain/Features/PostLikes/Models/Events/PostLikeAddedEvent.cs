namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Events;

public record PostLikeAddedEvent(
        string Id,
        string LikeId,
        string UserId,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
