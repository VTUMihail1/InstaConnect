namespace InstaConnect.Posts.Application.Features.PostComments.Commands.Add;

public record AddPostCommentCommandRequest(string Id, string Content, string UserId) : ICommandRequest<AddPostCommentCommandResponse>;
