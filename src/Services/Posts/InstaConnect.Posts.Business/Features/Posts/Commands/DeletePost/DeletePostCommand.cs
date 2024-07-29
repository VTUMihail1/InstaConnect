using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Features.Posts.Commands.DeletePost;

public record DeletePostCommand(string Id, string CurrentUserId) : ICommand;
