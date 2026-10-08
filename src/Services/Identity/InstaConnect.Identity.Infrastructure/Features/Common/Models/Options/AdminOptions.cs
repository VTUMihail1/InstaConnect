using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Features.Common.Models.Options;

public record AdminOptions(
	string Name,
	string Email,
	string FirstName,
	string LastName,
	string Password) : IApplicationOptions
{
	public const string SectionName = "AdminConfiguration";
}
