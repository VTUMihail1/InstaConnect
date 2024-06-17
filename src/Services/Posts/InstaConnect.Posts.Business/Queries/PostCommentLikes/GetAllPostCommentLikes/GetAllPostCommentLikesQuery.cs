using InstaConnect.Posts.Business.Models;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Posts.Business.Queries.PostCommentLikes.GetAllPostCommentLikes;

public class GetAllPostCommentLikesQuery : CollectionDTO, IQuery<ICollection<PostCommentLikeViewModel>>
{
}
