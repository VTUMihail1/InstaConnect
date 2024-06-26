using InstaConnect.Posts.Business.Read.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Read.Queries.PostComments.GetPostCommentById;

public class GetPostCommentByIdQuery : IQuery<PostCommentViewModel>
{
    public string Id { get; set; }
}
