using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Web.Models.Requests.Messages;

public class UpdateMessageRequest
{
    [FromRoute]
    public string Id { get; set; }

    [FromBody]
    public string Content { get; set; }
}
