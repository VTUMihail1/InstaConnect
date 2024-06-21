using InstaConnect.Posts.Business.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Posts.Business.Queries.PostCommentLikes.GetAllPostCommentLikes;

public class GetAllPostCommentLikesQuery : CollectionModel, IQuery<ICollection<PostCommentLikeViewModel>>
{
}
