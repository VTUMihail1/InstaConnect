using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;

public class DeletePostCommentRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
