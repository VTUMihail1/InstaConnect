using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Write.Commands.Posts.AddPost;

public class AddPostCommand : ICommand
{
    public string CurrentUserId { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
