namespace InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Add;

public record AddPostCommentLikeCommandRequest(string Id, string CommentId, string UserId) : ICommandRequest<AddPostCommentLikeCommandResponse>;
