using System.Security.Claims;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Binding;
using InstaConnect.Shared.Presentation.Binders.FromClaim;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public class AddFollowRequest
{
    [FromClaim(ClaimTypes.NameIdentifier)]
    public string CurrentUserId { get; set; } = string.Empty;

    [FromBody]
    public AddFollowBindingModel AddFollowBindingModel { get; set; } = new(string.Empty);
}
