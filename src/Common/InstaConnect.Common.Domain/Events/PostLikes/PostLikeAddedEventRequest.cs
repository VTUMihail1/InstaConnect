using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Events;

public record PostLikeAddedEventRequest(
        string Id,
        string UserId,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt)
    : IEventRequest;
