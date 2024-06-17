using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests.PostComment;

public class GetPostCommentByIdRequest
{
    [FromRoute]
    public string Id { get; set; }
}
