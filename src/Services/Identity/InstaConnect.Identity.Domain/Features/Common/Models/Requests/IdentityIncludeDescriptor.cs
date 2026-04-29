using InstaConnect.Common.Domain.Features.Data.Abstractions;

namespace InstaConnect.Identity.Domain.Features.Common.Models.Requests;

public record IdentityIncludeDescriptor(
	IdentityDestinationType DestinationType,
	IdentityIncludeType IncludeType)
	: IIncludeDescriptor<IdentityDestinationType, IdentityIncludeType>;
