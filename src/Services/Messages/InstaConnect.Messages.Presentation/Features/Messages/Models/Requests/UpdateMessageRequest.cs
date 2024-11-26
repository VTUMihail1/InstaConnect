using InstaConnect.Messages.Presentation.Features.Messages.Models.Binding;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Presentation.Features.Messages.Models.Requests;

public class UpdateMessageRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;

    [FromBody]
    public UpdateMessageBindingModel UpdateMessageBindingModel { get; set; } = new(string.Empty);
}
