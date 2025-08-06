using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.PostComments.Domain.Features.PostComments.Models.Events;

public record PostCommentAddedEventRequest(
        string Id,
        string CommentId,
        string Content,
        string UserId,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt)
    : IEventRequest;
