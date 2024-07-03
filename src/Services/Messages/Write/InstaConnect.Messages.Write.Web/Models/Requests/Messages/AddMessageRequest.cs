using InstaConnect.Messages.Write.Web.Models.Binding;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Write.Web.Models.Requests.Messages;

public class AddMessageRequest
{
    [FromBody]
    public AddMessageBindingModel AddMessageBindingModel { get; set; } = new();
}
