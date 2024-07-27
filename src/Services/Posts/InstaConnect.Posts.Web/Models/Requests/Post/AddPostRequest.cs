using InstaConnect.Posts.Write.Web.Models.Binding.Posts;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Write.Web.Models.Requests.Post;

public class AddPostRequest
{
    [FromBody]
    public AddPostBindingModel AddPostBindingModel { get; set; } = new(string.Empty, string.Empty);
}
