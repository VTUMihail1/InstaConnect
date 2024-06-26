using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests.Post;

public class UpdatePostRequest
{
    [FromRoute]
    public string PostId { get; set; }

    [FromBody]
    public UpdatePostBodyRequest UpdatePostBodyRequest { get; set; }
}
