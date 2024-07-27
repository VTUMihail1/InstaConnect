using InstaConnect.Posts.Business.Models.Post;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Commands.Posts.UpdatePost;

public record UpdatePostCommand(string Id, string CurrentUserId, string Title, string Content) : ICommand<PostCommandViewModel>;
