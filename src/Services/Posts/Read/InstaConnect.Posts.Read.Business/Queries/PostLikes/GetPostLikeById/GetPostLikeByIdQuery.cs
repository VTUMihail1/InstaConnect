using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Read.Business.Queries.PostLikes.GetPostLikeById;

public class GetPostLikeByIdQuery : IQuery<PostLikeViewModel>
{
    public string Id { get; set; } = string.Empty;
}
