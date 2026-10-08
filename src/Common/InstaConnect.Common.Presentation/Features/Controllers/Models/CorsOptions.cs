using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Common.Presentation.Features.Controllers.Models;

public record CorsOptions(
	string AllowedOrigins) : IApplicationOptions
{
	public const string SectionName = "CorsConfiguration";
}
