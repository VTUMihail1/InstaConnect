using InstaConnect.Posts.Web.Write.Models.Binding.PostComments;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Write.Models.Requests.PostComment;

public class AddPostCommentRequest
{
    [FromBody]
    public AddPostCommentBindingModel AddPostCommentBindingModel { get; set; } = new();
}
