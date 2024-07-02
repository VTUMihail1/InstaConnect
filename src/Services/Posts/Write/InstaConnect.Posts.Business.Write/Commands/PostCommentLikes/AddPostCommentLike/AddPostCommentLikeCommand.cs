using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Write.Commands.PostCommentLikes.AddPostCommentLike;

public class AddPostCommentLikeCommand : ICommand
{
    public string CurrentUserId { get; set; } = string.Empty;

    public string PostCommentId { get; set; } = string.Empty;
}
