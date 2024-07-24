using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Write.Web.Models.Requests.PostCommentLike;

public class DeletePostCommentLikeRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
