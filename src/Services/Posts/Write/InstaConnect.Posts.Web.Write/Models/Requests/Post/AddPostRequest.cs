using InstaConnect.Posts.Web.Write.Models.Binding.Posts;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests.Post;

public class AddPostRequest
{
    [FromBody]
    public AddPostBindingModel AddPostBindingModel { get; set; } = new();
}
