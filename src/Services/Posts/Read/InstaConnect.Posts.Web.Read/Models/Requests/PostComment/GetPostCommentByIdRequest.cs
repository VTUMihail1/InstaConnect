using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Read.Models.Requests.PostComment;

public class GetPostCommentByIdRequest
{
    [FromRoute]
    public string Id { get; set; }
}
