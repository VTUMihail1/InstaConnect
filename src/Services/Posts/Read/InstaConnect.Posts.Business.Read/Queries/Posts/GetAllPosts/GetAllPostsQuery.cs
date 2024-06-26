using InstaConnect.Posts.Business.Read.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Posts.Business.Read.Queries.Posts.GetAllPosts;

public class GetAllPostsQuery : CollectionModel, IQuery<ICollection<PostViewModel>>
{
}
