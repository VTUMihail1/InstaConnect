using InstaConnect.Shared.Web.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Read.Models.Requests.PostLike;

public class GetAllFilteredPostLikesRequest : CollectionRequest
{
    [FromQuery(Name = "userId")]
    public string UserId { get; set; } = string.Empty;

    [FromQuery(Name = "userName")]
    public string UserName { get; set; } = string.Empty;

    [FromQuery(Name = "postId")]
    public string PostId { get; set; } = string.Empty;
}
