using InstaConnect.Posts.Business.Read.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Posts.Business.Read.Queries.Posts.GetAllFilteredPosts;

public class GetAllFilteredPostsQuery : CollectionModel, IQuery<ICollection<PostViewModel>>
{
    public string UserId { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;
}
