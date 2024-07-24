using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Posts.Read.Business.Queries.PostCommentLikes.GetAllFilteredPostCommentLikes;

public class GetAllFilteredPostCommentLikesQuery : CollectionModel, IQuery<ICollection<PostCommentLikeQueryViewModel>>
{
    public string UserId { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string PostCommentId { get; set; } = string.Empty;
}
