using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Web.Write.Models.Requests.Messages;

public class DeleteMessageRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
