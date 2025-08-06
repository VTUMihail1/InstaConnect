using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Events;

public record PostAddedEventRequest(
        string Id,
        string Title,
        string Content,
        string UserId,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt)
    : IEventRequest;
