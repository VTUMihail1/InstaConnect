using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Posts.Application.Features.Posts.Commands.UpdatePost;

public record UpdatePostCommand(string Id, string CurrentUserId, string Title, string Content) : ICommand<PostCommandViewModel>;
