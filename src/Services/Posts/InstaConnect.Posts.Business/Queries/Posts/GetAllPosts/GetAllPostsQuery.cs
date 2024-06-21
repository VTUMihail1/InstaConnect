using InstaConnect.Posts.Business.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Posts.Business.Queries.Posts.GetAllPosts;

public class GetAllPostsQuery : CollectionModel, IQuery<ICollection<PostViewModel>>
{
}
