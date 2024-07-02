using InstaConnect.Posts.Web.Write.Models.Binding.PostLikes;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Write.Models.Requests.PostLike;

public class AddPostLikeRequest
{
    [FromBody]
    public AddPostLikeBindingModel AddPostLikeBindingModel { get; set; } = new();
}
