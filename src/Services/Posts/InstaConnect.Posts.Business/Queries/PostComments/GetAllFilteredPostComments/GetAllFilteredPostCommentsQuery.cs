using InstaConnect.Posts.Business.Models;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Posts.Business.Queries.PostComments.GetAllFilteredPostComments;

public class GetAllFilteredPostCommentsQuery : CollectionDTO, IQuery<ICollection<PostCommentViewModel>>
{
    public string UserId { get; set; }

    public string PostId { get; set; }

    public string PostCommentId { get; set; }
}
