using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.PostComments.Domain.Features.PostComments.Models.Events;

public record PostCommentDeletedEventRequest(
    string Id,
    string CommentId)
    : IEventRequest;
