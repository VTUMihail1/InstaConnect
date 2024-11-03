using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Web.Features.Messages.Models.Requests;

public class DeleteMessageRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
