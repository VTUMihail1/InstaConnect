using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Commands.PostComments.AddPostComment;

public class AddPostCommentCommand : ICommand
{
    public string PostId { get; set; }

    public string Content { get; set; }
}
