using InstaConnect.Shared.Presentation.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;

public class GetAllPostCommentLikesRequest : CollectionReadRequest
{
    [FromQuery(Name = "userId")]
    public string UserId { get; set; } = string.Empty;

    [FromQuery(Name = "userName")]
    public string UserName { get; set; } = string.Empty;

    [FromQuery(Name = "postCommentId")]
    public string PostCommentId { get; set; } = string.Empty;
}
