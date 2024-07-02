using InstaConnect.Messages.Web.Write.Models.Binding;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Web.Write.Models.Requests.Messages;

public class AddMessageRequest
{
    [FromBody]
    public AddMessageBindingModel AddMessageBindingModel { get; set; } = new();
}
