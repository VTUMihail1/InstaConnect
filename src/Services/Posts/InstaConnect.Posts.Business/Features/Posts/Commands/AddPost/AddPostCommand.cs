using InstaConnect.Posts.Business.Features.Posts.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Features.Posts.Commands.AddPost;

public record AddPostCommand(string CurrentUserId, string Title, string Content) : ICommand<PostCommandViewModel>;
