using InstaConnect.Shared.Web.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Read.Models.Requests.PostComment;

public class GetPostCommentsCollectionRequest : CollectionRequest
{
    [FromQuery(Name = "userName")]
    public string UserName { get; set; } = string.Empty;

    [FromQuery(Name = "postId")]
    public string PostId { get; set; } = string.Empty;
}
