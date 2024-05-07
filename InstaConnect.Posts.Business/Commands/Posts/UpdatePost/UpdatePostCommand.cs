using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Posts.Business.Commands.Posts.UpdatePost;

public class UpdatePostCommand : ICommand
{
    public string Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }
}
