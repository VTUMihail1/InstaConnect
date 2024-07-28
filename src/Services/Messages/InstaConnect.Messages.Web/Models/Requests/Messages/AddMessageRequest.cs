using InstaConnect.Messages.Web.Models.Binding;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Web.Models.Requests.Messages;

public class AddMessageRequest
{
    [FromBody]
    public AddMessageBindingModel AddMessageBindingModel { get; set; } = new(string.Empty, string.Empty);
}
