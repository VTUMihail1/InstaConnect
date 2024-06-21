using InstaConnect.Posts.Business.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Posts.Business.Queries.PostComments.GetAllFilteredPostComments;

public class GetAllFilteredPostCommentsQuery : CollectionModel, IQuery<ICollection<PostCommentViewModel>>
{
    public string UserId { get; set; }

    public string PostId { get; set; }
}
