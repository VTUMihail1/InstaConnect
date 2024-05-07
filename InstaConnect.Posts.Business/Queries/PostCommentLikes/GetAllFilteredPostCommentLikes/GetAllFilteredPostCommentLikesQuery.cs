using InstaConnect.Posts.Business.Models;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Posts.Business.Queries.PostCommentLikes.GetAllFilteredPostCommentLikes;

public class GetAllFilteredPostCommentLikesQuery : CollectionDTO, IQuery<ICollection<PostCommentLikeViewDTO>>
{
    public string UserId { get; set; }

    public string PostCommentId { get; set; }
}
