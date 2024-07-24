using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Posts.Read.Business.Queries.PostComments.GetAllFilteredPostComments;

public class GetAllFilteredPostCommentsQuery : CollectionModel, IQuery<ICollection<PostCommentQueryViewModel>>
{
    public string UserId { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string PostId { get; set; } = string.Empty;
}
