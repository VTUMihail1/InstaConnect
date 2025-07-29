using InstaConnect.PostComments.Application.Features.PostComments.Commands.Add;

namespace InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;

public record UpdatePostCommentCommand(
    string Id,
    string CommentId,
    string UserId,
    string Content);
