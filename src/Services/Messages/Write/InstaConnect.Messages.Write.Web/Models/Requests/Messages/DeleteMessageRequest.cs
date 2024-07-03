using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Write.Web.Models.Requests.Messages;

public class DeleteMessageRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
