using InstaConnect.Posts.Application.Features.Users.Models;

namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Delete;

public record DeletePostCommentCommandRequest(
    PostCommentIdPayload Id,
    UserIdPayload UserId) : ICommandRequest;
