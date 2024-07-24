using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Write.Business.Commands.PostComments.UpdatePostComment;

public class UpdatePostCommentCommand : ICommand<PostCommentCommandViewModel>
{
    public string Id { get; set; } = string.Empty;

    public string CurrentUserId { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
