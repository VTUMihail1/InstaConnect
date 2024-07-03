using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Read.Business.Queries.PostComments.GetPostCommentById;

public class GetPostCommentByIdQuery : IQuery<PostCommentViewModel>
{
    public string Id { get; set; } = string.Empty;
}
