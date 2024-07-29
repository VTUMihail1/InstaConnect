using InstaConnect.Posts.Web.Features.Posts.Models.Binding;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Features.Posts.Models.Requests;

public class AddPostRequest
{
    [FromBody]
    public AddPostBindingModel AddPostBindingModel { get; set; } = new(string.Empty, string.Empty);
}
