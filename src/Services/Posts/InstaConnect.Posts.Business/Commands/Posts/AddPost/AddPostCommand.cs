using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Posts.Business.Commands.Posts.AddPost;

public class AddPostCommand : ICommand
{
    public string Title { get; set; }

    public string Content { get; set; }
}
