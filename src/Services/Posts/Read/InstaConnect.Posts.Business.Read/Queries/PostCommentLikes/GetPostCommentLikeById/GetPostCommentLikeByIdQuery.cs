using InstaConnect.Posts.Business.Read.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Read.Queries.PostCommentLikes.GetPostCommentLikeById;

public class GetPostCommentLikeByIdQuery : IQuery<PostCommentLikeViewModel>
{
    public string Id { get; set; } = string.Empty;
}
