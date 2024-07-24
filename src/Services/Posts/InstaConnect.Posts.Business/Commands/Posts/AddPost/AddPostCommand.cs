using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Write.Business.Commands.Posts.AddPost;

public class AddPostCommand : ICommand<PostCommandViewModel>
{
    public string CurrentUserId { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
