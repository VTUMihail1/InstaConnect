using InstaConnect.Posts.Business.Read.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Read.Queries.Posts.GetPostById;

public class GetPostByIdQuery : IQuery<PostViewModel>
{
    public string Id { get; set; }
}
