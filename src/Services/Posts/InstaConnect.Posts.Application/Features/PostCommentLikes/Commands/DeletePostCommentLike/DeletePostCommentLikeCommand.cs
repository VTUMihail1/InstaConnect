using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Features.PostCommentLikes.Commands.DeletePostCommentLike;

public record DeletePostCommentLikeCommand(string Id, string CurrentUserId) : ICommand;
