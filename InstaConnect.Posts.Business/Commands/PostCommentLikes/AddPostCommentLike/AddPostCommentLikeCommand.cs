using InstaConnect.Shared.Business.Messaging;
using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Posts.Business.Commands.PostCommentLikes.AddPostCommentLike;

public class AddPostCommentLikeCommand : ICommand
{
    public string PostCommentId { get; set; }
}
