using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Common.Presentation.Features.Common.Models;

public record MainOptions(
	string BaseUrl) : IApplicationOptions
{
	public const string SectionName = "MainConfiguration";
}
