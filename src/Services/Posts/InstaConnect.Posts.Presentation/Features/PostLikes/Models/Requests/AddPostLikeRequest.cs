using InstaConnect.Posts.Web.Features.PostLikes.Models.Binding;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Features.PostLikes.Models.Requests;

public class AddPostLikeRequest
{
    [FromBody]
    public AddPostLikeBindingModel AddPostLikeBindingModel { get; set; } = new(string.Empty);
}
