using InstaConnect.Identity.Presentation.Features.Users.Models.Bindings;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record VerifyForgotPasswordTokenRequest(
    [FromRoute] string UserId,
    [FromRoute] string Token,
    [FromBody] VerifyForgotPasswordTokenBody Body);
