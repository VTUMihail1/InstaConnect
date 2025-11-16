namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Delete;

public record DeletePostCommentLikeCommandRequest(PostCommentLikeIdPayload Id) : ICommandRequest;
