using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests.PostCommentLike;

public class GetPostCommentLikeByIdRequestModel
{
    [FromRoute]
    public string Id { get; set; }
}
