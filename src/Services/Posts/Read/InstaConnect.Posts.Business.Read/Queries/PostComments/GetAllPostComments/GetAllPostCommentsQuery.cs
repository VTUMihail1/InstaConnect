using InstaConnect.Posts.Business.Read.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;

namespace InstaConnect.Posts.Business.Read.Queries.PostComments.GetAllPostComments;

public class GetAllPostCommentsQuery : CollectionModel, IQuery<ICollection<PostCommentViewModel>>
{
}
