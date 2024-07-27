using InstaConnect.Posts.Business.Models.Post;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Commands.Posts.AddPost;

public record AddPostCommand(string CurrentUserId, string Title, string Content) : ICommand<PostCommandViewModel>;
