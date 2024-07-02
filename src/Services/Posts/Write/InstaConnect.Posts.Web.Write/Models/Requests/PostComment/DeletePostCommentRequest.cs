using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests.PostComment;

public class DeletePostCommentRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
