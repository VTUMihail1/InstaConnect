using InstaConnect.Posts.Presentation.Features.PostComments.Models.Binding;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;

public class AddPostCommentRequest
{
    [FromBody]
    public AddPostCommentBindingModel AddPostCommentBindingModel { get; set; } = new(string.Empty, string.Empty);
}
