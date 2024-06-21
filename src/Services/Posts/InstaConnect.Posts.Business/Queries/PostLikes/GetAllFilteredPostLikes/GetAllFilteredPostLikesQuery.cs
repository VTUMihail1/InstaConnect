using InstaConnect.Posts.Business.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Posts.Business.Queries.PostLikes.GetAllFilteredPostLikes;

public class GetAllFilteredPostLikesQuery : CollectionModel, IQuery<ICollection<PostLikeViewModel>>
{
    public string UserId { get; set; }

    public string PostId { get; set; }
}
