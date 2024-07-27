using InstaConnect.Posts.Write.Web.Models.Binding.PostCommentLikes;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Write.Web.Models.Requests.PostCommentLike;

public class AddPostCommentLikeRequest
{
    [FromBody]
    public AddPostCommentLikeBindingModel AddPostCommentLikeBindingModel { get; set; } = new(string.Empty);
}
