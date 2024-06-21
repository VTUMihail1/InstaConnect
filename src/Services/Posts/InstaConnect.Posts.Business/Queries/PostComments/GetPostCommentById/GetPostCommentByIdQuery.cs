using InstaConnect.Posts.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Queries.PostComments.GetPostCommentById;

public class GetPostCommentByIdQuery : IQuery<PostCommentViewModel>
{
    public string Id { get; set; }
}
