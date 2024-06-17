using InstaConnect.Shared.Web.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests.PostCommentLike;

public class GetPostCommentLikesCollectionRequest : CollectionRequest
{
    [FromQuery(Name = "userName")]
    public string UserName { get; set; } = string.Empty;

    [FromQuery(Name = "postCommentId")]
    public string PostCommentId { get; set; } = string.Empty;
}
