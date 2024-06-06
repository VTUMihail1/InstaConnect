using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests.PostComment;

public class GetPostCommentByIdRequestModel
{
    [FromRoute]
    public string Id { get; set; }
}
