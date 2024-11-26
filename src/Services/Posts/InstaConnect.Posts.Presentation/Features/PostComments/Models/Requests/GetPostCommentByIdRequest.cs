using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;

public class GetPostCommentByIdRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
