using InstaConnect.Posts.Application.Features.Users.Models;

namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Update;

public record UpdatePostCommentCommandRequest(
    PostCommentIdPayload Id,
    UserIdPayload UserId,
    string Content) : ICommandRequest<UpdatePostCommentCommandResponse>;
