using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Read.Web.Models.Requests.Post;

public class GetPostByIdRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
