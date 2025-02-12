using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Models.Requests;

public record AddForgotPasswordTokenRequest([FromRoute] string Email);
