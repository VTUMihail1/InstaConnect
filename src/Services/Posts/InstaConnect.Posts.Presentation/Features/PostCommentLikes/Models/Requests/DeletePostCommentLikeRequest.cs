using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Features.PostCommentLikes.Models.Requests;

public class DeletePostCommentLikeRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
