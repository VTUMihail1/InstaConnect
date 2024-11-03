using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Features.PostLikes.Models.Requests;

public class GetPostLikeByIdRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
