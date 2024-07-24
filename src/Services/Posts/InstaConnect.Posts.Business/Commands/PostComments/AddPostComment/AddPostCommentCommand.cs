using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Write.Business.Commands.PostComments.AddPostComment;

public class AddPostCommentCommand : ICommand<PostCommentCommandViewModel>
{
    public string CurrentUserId { get; set; } = string.Empty;

    public string PostId { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
