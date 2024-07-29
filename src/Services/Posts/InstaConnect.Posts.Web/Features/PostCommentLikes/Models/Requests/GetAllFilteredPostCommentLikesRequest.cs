using InstaConnect.Shared.Web.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Features.PostCommentLikes.Models.Requests;

public class GetAllFilteredPostCommentLikesRequest : CollectionReadRequest
{
    [FromQuery(Name = "userId")]
    public string UserId { get; set; } = string.Empty;

    [FromQuery(Name = "userName")]
    public string UserName { get; set; } = string.Empty;

    [FromQuery(Name = "postCommentId")]
    public string PostCommentId { get; set; } = string.Empty;
}
