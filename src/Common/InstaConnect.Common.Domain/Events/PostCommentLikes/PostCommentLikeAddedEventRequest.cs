using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Events;

public record PostCommentLikeAddedEventRequest(
        string Id,
        string CommentId,
        string UserId,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt)
    : IEventRequest;
