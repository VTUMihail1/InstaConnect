using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Commands.PostLikes.DeletePostLike;

public record DeletePostLikeCommand(string Id, string CurrentUserId) : ICommand;
