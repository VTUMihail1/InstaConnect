using InstaConnect.Posts.Application.Features.Users.Models;

namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Add;

public record AddPostCommentCommandRequest(PostIdPayload Id, string Content, UserIdPayload UserId) : ICommandRequest<AddPostCommentCommandResponse>;
