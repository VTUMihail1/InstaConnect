using InstaConnect.Posts.Business.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Posts.Business.Queries.PostCommentLikes.GetAllFilteredPostCommentLikes;

public class GetAllFilteredPostCommentLikesQuery : CollectionModel, IQuery<ICollection<PostCommentLikeViewModel>>
{
    public string UserId { get; set; }

    public string UserName { get; set; }

    public string PostCommentId { get; set; }
}
