using System.Security.Claims;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Binding;
using InstaConnect.Shared.Presentation.Binders.FromClaim;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Presentation.Features.Messages.Models.Requests;

public class AddMessageRequest
{
    [FromClaim(ClaimTypes.NameIdentifier)]
    public string CurrentUserId { get; set; } = string.Empty;

    [FromBody]
    public AddMessageBindingModel AddMessageBindingModel { get; set; } = new(string.Empty, string.Empty);
}
