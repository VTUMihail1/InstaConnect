using InstaConnect.Posts.Business.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Posts.Business.Queries.PostLikes.GetAllPostLikes;

public class GetAllPostLikesQuery : CollectionModel, IQuery<ICollection<PostLikeViewModel>>
{
}
