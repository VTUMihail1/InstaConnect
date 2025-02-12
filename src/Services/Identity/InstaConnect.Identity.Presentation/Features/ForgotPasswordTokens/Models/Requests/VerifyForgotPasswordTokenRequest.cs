using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Models.Bodies;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Models.Requests;

public record VerifyForgotPasswordTokenRequest(
    [FromRoute] string UserId,
    [FromRoute] string Token,
    [FromBody] VerifyForgotPasswordTokenBody Body);
