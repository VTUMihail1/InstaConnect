using InstaConnect.Identity.Domain.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;

public record EmailConfirmationTokenInclude(ICollection<IdentityIncludeDescriptor> Descriptors)
    : IInclude<IdentityDestinationType, IdentityIncludeType, IdentityIncludeDescriptor>;
