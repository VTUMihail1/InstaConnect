using InstaConnect.Posts.Write.Web.Models.Binding.PostComments;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Write.Web.Models.Requests.PostComment;

public class AddPostCommentRequest
{
    [FromBody]
    public AddPostCommentBindingModel AddPostCommentBindingModel { get; set; } = new(string.Empty, string.Empty);
}
