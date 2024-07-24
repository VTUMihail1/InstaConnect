using InstaConnect.Posts.Write.Web.Models.Binding.Posts;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Write.Web.Models.Requests.Post;

public class UpdatePostRequest
{
    [FromRoute]
    public string PostId { get; set; } = string.Empty;

    [FromBody]
    public UpdatePostBindingModel UpdatePostBindingModel { get; set; } = new();
}
