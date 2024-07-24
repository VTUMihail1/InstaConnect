using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Read.Business.Queries.Posts.GetPostById;

public class GetPostByIdQuery : IQuery<PostQueryViewModel>
{
    public string Id { get; set; } = string.Empty;
}
