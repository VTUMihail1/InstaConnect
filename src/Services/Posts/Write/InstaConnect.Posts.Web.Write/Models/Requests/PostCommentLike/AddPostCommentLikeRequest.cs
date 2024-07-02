using InstaConnect.Posts.Web.Write.Models.Binding.PostCommentLikes;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Write.Models.Requests.PostCommentLike;

public class AddPostCommentLikeRequest
{
    [FromBody]
    public AddPostCommentLikeBindingModel AddPostCommentLikeBindingModel { get; set; } = new();
}
