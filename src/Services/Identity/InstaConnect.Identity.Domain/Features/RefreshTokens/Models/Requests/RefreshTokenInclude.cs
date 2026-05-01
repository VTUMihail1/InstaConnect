using InstaConnect.Common.Domain.Features.Data.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;

public record RefreshTokenInclude(ICollection<IdentityIncludeDescriptor> Descriptors)
	: IInclude<IdentityDestinationType, IdentityIncludeType, IdentityIncludeDescriptor>;
