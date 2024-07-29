using InstaConnect.Messages.Web.Features.Messages.Models.Binding;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Web.Features.Messages.Models.Requests;

public class AddMessageRequest
{
    [FromBody]
    public AddMessageBindingModel AddMessageBindingModel { get; set; } = new(string.Empty, string.Empty);
}
