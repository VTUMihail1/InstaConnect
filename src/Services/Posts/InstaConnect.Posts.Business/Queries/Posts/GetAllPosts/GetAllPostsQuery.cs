using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Posts.Read.Business.Queries.Posts.GetAllPosts;

public class GetAllPostsQuery : CollectionModel, IQuery<ICollection<PostQueryViewModel>>
{
}
