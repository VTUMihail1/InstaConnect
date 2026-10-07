using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Options;

public record RefreshTokenOptions(
	int LifetimeSeconds) : IApplicationOptions
{
	public const string SectionName = "RefreshTokenConfiguration";
}
