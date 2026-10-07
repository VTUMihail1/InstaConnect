using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Options;

public record ForgotPasswordTokenOptions(
	int LifetimeSeconds) : IApplicationOptions
{
	public const string SectionName = "ForgotPasswordTokenConfiguration";
}
