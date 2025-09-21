using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Events;

public record FollowDeletedEventRequest(string FollowerId, string FollowingId)
    : IEventRequest;
