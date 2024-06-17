using InstaConnect.Posts.Business.Models;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Posts.Business.Queries.PostLikes.GetAllFilteredPostLikes;

public class GetAllFilteredPostLikesQuery : CollectionDTO, IQuery<ICollection<PostLikeViewModel>>
{
    public string UserId { get; set; }

    public string PostId { get; set; }
}
