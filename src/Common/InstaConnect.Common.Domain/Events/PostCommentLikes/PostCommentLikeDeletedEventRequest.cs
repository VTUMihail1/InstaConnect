using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Events;

public record PostCommentLikeDeletedEventRequest(
    string Id,
    string CommentId,
    string UserId)
    : IEventRequest;
