using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Posts.Business.Commands.PostCommentLikes.DeletePostCommentLike;

public class DeletePostCommentLikeCommand : ICommand
{
    public string Id { get; set; }
}
