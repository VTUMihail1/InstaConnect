using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Commands.PostComments.DeletePostComment;

public class DeletePostCommentCommand : ICommand
{
    public string Id { get; set; }
}
