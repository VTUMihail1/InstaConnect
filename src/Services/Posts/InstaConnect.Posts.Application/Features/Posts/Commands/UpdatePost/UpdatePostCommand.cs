using InstaConnect.Posts.Business.Features.Posts.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Features.Posts.Commands.UpdatePost;

public record UpdatePostCommand(string Id, string CurrentUserId, string Title, string Content) : ICommand<PostCommandViewModel>;
