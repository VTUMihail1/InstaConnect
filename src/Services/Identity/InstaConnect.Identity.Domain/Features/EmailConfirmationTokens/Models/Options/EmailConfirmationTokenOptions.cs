using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Options;

public record EmailConfirmationTokenOptions(
	int LifetimeSeconds) : IApplicationOptions
{
	public const string SectionName = "EmailConfirmationTokenConfiguration";
}
