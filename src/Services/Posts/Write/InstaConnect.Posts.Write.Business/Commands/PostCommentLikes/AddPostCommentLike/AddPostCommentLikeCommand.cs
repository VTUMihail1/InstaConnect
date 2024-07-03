using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Write.Business.Commands.PostCommentLikes.AddPostCommentLike;

public class AddPostCommentLikeCommand : ICommand
{
    public string CurrentUserId { get; set; } = string.Empty;

    public string PostCommentId { get; set; } = string.Empty;
}
