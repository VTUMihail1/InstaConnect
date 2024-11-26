using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Binding;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;

public class AddPostLikeRequest
{
    [FromBody]
    public AddPostLikeBindingModel AddPostLikeBindingModel { get; set; } = new(string.Empty);
}
