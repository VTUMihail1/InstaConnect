using System.Security.Claims;
using InstaConnect.Messages.Presentation.Features.Messages.Models.Binding;
using InstaConnect.Shared.Presentation.Binders.FromClaim;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Presentation.Features.Messages.Models.Requests;

public class UpdateMessageRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;

    [FromClaim(ClaimTypes.NameIdentifier)]
    public string CurrentUserId { get; set; } = string.Empty;

    [FromBody]
    public UpdateMessageBindingModel UpdateMessageBindingModel { get; set; } = new(string.Empty);
}
