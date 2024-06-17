using InstaConnect.Posts.Business.Models;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Posts.Business.Queries.Posts.GetAllPosts;

public class GetAllPostsQuery : CollectionDTO, IQuery<ICollection<PostViewModel>>
{
}
