using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Read.Web.Models.Requests.PostLike;

public class GetPostLikeByIdRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
