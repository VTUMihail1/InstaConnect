using InstaConnect.Posts.Business.Read.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Read.Queries.PostLikes.GetPostLikeById;

public class GetPostLikeByIdQuery : IQuery<PostLikeViewModel>
{
    public string Id { get; set; } = string.Empty;
}
