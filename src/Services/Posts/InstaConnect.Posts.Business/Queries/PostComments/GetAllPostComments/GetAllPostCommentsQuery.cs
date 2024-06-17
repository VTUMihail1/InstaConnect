using InstaConnect.Posts.Business.Models;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Posts.Business.Queries.PostComments.GetAllPostComments;

public class GetAllPostCommentsQuery : CollectionDTO, IQuery<ICollection<PostCommentViewModel>>
{
}
