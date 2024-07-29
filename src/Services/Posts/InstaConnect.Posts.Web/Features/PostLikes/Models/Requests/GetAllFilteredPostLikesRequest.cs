using InstaConnect.Shared.Web.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Features.PostLikes.Models.Requests;

public class GetAllFilteredPostLikesRequest : CollectionReadRequest
{
    [FromQuery(Name = "userId")]
    public string UserId { get; set; } = string.Empty;

    [FromQuery(Name = "userName")]
    public string UserName { get; set; } = string.Empty;

    [FromQuery(Name = "postId")]
    public string PostId { get; set; } = string.Empty;
}
