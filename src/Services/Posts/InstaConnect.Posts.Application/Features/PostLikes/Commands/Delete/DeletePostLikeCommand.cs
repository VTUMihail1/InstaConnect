using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Posts.Application.Features.PostLikes.Commands.DeletePostLike;

public record DeletePostLikeCommand(string Id, string CurrentUserId) : ICommand;
