using InstaConnect.Identity.Domain.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;

public record RefreshTokenInclude(ICollection<IdentityIncludeDescriptor> Descriptors)
    : IInclude<IdentityDestinationType, IdentityIncludeType, IdentityIncludeDescriptor>;
