using InstaConnect.Posts.Web.Write.Models.Binding.PostComments;
using InstaConnect.Posts.Web.Write.Models.Binding.Posts;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests.PostComment;

public class UpdatePostCommentRequest
{
    [FromRoute]
    public string PostId { get; set; } = string.Empty;

    [FromBody]
    public UpdatePostCommentBindingModel UpdatePostCommentBindingModel { get; set; } = new();
}
