using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Models.Bodies;

namespace InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Models.Requests;

public record VerifyForgotPasswordTokenApiRequest(
	[FromRoute] string Id,
	[FromRoute] string Value,
	[FromBody] VerifyForgotPasswordTokenApiBody Body);
