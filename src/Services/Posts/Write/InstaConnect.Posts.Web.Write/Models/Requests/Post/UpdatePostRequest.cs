using InstaConnect.Posts.Web.Write.Models.Binding.Posts;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Write.Models.Requests.Post;

public class UpdatePostRequest
{
    [FromRoute]
    public string PostId { get; set; } = string.Empty;

    [FromBody]
    public UpdatePostBindingModel UpdatePostBindingModel { get; set; } = new();
}
