using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Events;

public record PostUpdatedEventRequest(
        string Id,
        string Title,
        string Content,
        string UserId,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt)
    : IEventRequest;
