using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Commands.PostCommentLikes.AddPostCommentLike;

public class AddPostCommentLikeCommand : ICommand
{
    public string PostCommentId { get; set; }
}
