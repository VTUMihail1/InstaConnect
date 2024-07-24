using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Read.Web.Models.Requests.PostCommentLike;

public class GetPostCommentLikeByIdRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
