using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Read.Models.Requests.Post;

public class GetPostByIdRequest
{
    [FromRoute]
    public string Id { get; set; }
}
