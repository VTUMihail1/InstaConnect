using InstaConnect.Messages.Web.Write.Models.Binding;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Web.Write.Models.Requests.Messages;

public class UpdateMessageRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;

    [FromBody]
    public UpdateMessageBindingModel UpdateMessageBindingModel { get; set; } = new();
}
