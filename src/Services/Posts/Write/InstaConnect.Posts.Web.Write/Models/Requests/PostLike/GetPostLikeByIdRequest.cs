using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests.PostLike;

public class GetPostLikeByIdRequest
{
    [FromRoute]
    public string Id { get; set; }
}
