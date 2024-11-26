using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Presentation.Features.Messages.Models.Requests;

public class DeleteMessageRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;
}
