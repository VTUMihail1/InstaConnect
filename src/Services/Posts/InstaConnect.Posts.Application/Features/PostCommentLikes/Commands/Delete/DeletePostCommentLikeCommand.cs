using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.DeletePostCommentLike;

public record DeletePostCommentLikeCommand(string Id, string CurrentUserId) : ICommand;
