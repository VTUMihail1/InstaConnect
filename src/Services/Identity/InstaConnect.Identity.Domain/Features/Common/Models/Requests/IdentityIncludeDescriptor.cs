using InstaConnect.Common.Domain.Features.Databases.Abstractions;

namespace InstaConnect.Identity.Domain.Features.Common.Models.Requests;

public record IdentityIncludeDescriptor(
	IdentityDestinationType DestinationType,
	IdentityIncludeType IncludeType)
	: IIncludeDescriptor<IdentityDestinationType, IdentityIncludeType>;
