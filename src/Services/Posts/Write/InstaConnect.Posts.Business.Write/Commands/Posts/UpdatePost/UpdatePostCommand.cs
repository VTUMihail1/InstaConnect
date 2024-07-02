using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Write.Commands.Posts.UpdatePost;

public class UpdatePostCommand : ICommand
{
    public string Id { get; set; } = string.Empty;

    public string CurrentUserId { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
