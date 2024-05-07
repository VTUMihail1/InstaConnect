using InstaConnect.Posts.Business.Models;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Posts.Business.Queries.PostLikes.GetAllPostLikes;

public class GetAllPostLikesQuery : CollectionDTO, IQuery<ICollection<PostLikeViewDTO>>
{
}
