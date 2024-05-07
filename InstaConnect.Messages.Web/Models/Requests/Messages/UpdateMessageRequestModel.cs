using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Web.Models.Requests.PostComment;

public class UpdateMessageRequestModel
{
    [FromRoute]
    public string Id { get; set; }

    [FromRoute]
    public string SenderId { get; set; }

    [FromBody]
    public string Content { get; set; }
}
