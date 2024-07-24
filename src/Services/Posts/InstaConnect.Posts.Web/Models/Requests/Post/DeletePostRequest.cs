using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Write.Web.Models.Requests.Post;

public class DeletePostRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
