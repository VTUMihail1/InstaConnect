using InstaConnect.Shared.Web.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Features.Posts.Models.Requests;

public class GetAllFilteredPostsRequest : CollectionReadRequest
{
    [FromQuery(Name = "userId")]
    public string UserId { get; set; } = string.Empty;

    [FromQuery(Name = "userName")]
    public string UserName { get; set; } = string.Empty;

    [FromQuery(Name = "title")]
    public string Title { get; set; } = string.Empty;
}
