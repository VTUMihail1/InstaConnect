using InstaConnect.Posts.Write.Web.Models.Binding.PostLikes;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Write.Web.Models.Requests.PostLike;

public class AddPostLikeRequest
{
    [FromBody]
    public AddPostLikeBindingModel AddPostLikeBindingModel { get; set; } = new();
}
