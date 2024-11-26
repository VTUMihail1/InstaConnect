using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;

public class DeletePostCommentLikeRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
