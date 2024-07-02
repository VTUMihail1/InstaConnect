using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Commands.PostComments.UpdatePostComment;

public class UpdatePostCommentCommand : ICommand
{
    public string Id { get; set; } = string.Empty;

    public string CurrentUserId { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
