namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Delete;

public record DeletePostCommentLikeCommand(string Id, string CurrentUserId) : ICommand;
