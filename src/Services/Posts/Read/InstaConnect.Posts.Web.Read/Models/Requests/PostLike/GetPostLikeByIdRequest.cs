using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Read.Models.Requests.PostLike;

public class GetPostLikeByIdRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
