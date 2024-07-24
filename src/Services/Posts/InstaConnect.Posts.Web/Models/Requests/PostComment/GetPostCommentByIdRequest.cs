using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Read.Web.Models.Requests.PostComment;

public class GetPostCommentByIdRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
