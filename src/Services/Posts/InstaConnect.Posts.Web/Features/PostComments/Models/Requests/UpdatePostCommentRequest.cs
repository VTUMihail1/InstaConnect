using InstaConnect.Posts.Web.Features.PostComments.Models.Binding;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Features.PostComments.Models.Requests;

public class UpdatePostCommentRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;

    [FromBody]
    public UpdatePostCommentBindingModel UpdatePostCommentBindingModel { get; set; } = new(string.Empty);
}
