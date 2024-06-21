using InstaConnect.Posts.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Queries.PostCommentLikes.GetPostCommentLikeById;

public class GetPostCommentLikeByIdQuery : IQuery<PostCommentLikeViewModel>
{
    public string Id { get; set; }
}
