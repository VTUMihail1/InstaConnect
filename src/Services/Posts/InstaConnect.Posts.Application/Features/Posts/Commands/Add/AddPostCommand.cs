using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Posts.Application.Features.Posts.Commands.AddPost;

public record AddPostCommand(string CurrentUserId, string Title, string Content) : ICommand<PostCommandViewModel>;
