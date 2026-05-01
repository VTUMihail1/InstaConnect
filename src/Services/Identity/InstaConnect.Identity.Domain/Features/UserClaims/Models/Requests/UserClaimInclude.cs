using InstaConnect.Common.Domain.Features.Data.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;

public record UserClaimInclude(ICollection<IdentityIncludeDescriptor> Descriptors)
	: IInclude<IdentityDestinationType, IdentityIncludeType, IdentityIncludeDescriptor>;
