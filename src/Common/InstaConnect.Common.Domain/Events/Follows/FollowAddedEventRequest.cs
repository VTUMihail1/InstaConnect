using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Events;

public record FollowAddedEventRequest(
        string FollowerId,
        string FollowingId,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt)
    : IEventRequest;
