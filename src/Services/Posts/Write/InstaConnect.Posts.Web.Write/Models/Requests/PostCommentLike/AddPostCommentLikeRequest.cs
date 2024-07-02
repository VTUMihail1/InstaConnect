using InstaConnect.Posts.Web.Write.Models.Binding.PostCommentLikes;
using InstaConnect.Posts.Web.Write.Models.Binding.PostComments;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests.PostCommentLike;

public class AddPostCommentLikeRequest
{
    [FromBody]
    public AddPostCommentLikeBindingModel AddPostCommentLikeBindingModel { get; set; } = new();
}
