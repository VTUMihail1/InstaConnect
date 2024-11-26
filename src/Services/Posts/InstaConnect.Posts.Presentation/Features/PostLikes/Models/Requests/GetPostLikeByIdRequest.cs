using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;

public class GetPostLikeByIdRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
