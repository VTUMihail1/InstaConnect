using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Web.Models.Requests.Post;

public class UpdatePostRequestModel
{
    [FromRoute]
    public string PostId { get; set; }

    [FromRoute]
    public string UserId { get; set; }

    [FromBody]
    public UpdatePostBodyRequestModel UpdatePostBodyRequestModel { get; set; }
}
