using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Commands.PostCommentLikes.DeletePostCommentLike;

public record DeletePostCommentLikeCommand(string Id, string CurrentUserId) : ICommand;
