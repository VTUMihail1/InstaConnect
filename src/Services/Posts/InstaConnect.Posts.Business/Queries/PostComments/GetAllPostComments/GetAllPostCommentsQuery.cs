using InstaConnect.Posts.Business.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Posts.Business.Queries.PostComments.GetAllPostComments;

public class GetAllPostCommentsQuery : CollectionModel, IQuery<ICollection<PostCommentViewModel>>
{
}
