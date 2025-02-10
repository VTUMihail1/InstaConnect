using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record VerifyEmailConfirmationTokenRequest([FromRoute] string Token, [FromRoute] string UserId);
