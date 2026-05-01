using InstaConnect.Common.Domain.Features.Data.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;

public record EmailConfirmationTokenInclude(ICollection<IdentityIncludeDescriptor> Descriptors)
	: IInclude<IdentityDestinationType, IdentityIncludeType, IdentityIncludeDescriptor>;
