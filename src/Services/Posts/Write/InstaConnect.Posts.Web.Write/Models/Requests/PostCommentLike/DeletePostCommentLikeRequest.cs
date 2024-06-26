using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests.PostCommentLike;

public class DeletePostCommentLikeRequest
{
    [FromRoute]
    public string Id { get; set; }
}
