using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Read.Models.Requests.PostCommentLike;

public class GetPostCommentLikeByIdRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
