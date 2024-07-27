using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Commands.Posts.DeletePost;

public record DeletePostCommand(string Id, string CurrentUserId) : ICommand;
