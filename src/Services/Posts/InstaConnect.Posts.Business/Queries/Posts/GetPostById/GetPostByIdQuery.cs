using InstaConnect.Posts.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Queries.Posts.GetPostById;

public class GetPostByIdQuery : IQuery<PostViewModel>
{
    public string Id { get; set; }
}
