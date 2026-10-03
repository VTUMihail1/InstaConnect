using InstaConnect.Common.Domain.Features.Databases.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

public record UserInclude(ICollection<IdentityIncludeDescriptor> Descriptors)
	: IInclude<IdentityDestinationType, IdentityIncludeType, IdentityIncludeDescriptor>;
