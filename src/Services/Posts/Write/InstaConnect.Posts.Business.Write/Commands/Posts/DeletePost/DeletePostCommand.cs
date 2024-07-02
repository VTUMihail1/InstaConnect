using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Write.Commands.Posts.DeletePost;

public class DeletePostCommand : ICommand
{
    public string Id { get; set; } = string.Empty;

    public string CurrentUserId { get; set; } = string.Empty;
}
