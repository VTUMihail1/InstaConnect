using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Features.PostLikes.Commands.DeletePostLike;

public record DeletePostLikeCommand(string Id, string CurrentUserId) : ICommand;
