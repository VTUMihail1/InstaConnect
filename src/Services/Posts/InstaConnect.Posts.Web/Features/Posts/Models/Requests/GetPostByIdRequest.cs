using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Features.Posts.Models.Requests;

public class GetPostByIdRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
