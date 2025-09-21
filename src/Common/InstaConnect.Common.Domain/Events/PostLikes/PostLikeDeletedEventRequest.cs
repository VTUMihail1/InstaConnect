using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Events;

public record PostLikeDeletedEventRequest(string Id, string UserId)
    : IEventRequest;
