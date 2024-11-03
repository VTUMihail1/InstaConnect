using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Features.PostComments.Models.Requests;

public class GetPostCommentByIdRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
