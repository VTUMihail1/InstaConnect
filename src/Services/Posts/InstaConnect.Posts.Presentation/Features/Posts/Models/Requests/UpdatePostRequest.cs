using InstaConnect.Posts.Web.Features.Posts.Models.Binding;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Features.Posts.Models.Requests;

public class UpdatePostRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;

    [FromBody]
    public UpdatePostBindingModel UpdatePostBindingModel { get; set; } = new(string.Empty, string.Empty);
}
