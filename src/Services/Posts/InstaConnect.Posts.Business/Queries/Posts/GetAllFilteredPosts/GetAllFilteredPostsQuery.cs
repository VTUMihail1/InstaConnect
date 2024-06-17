using InstaConnect.Posts.Business.Models;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Posts.Business.Queries.Posts.GetAllFilteredPosts;

public class GetAllFilteredPostsQuery : CollectionDTO, IQuery<ICollection<PostViewModel>>
{
    public string UserId { get; set; }

    public string UserName { get; set; }

    public string Title { get; set; }
}
