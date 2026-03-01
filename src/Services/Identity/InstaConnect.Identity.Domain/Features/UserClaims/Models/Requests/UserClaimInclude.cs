using InstaConnect.Identity.Domain.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;

public record UserClaimInclude(ICollection<IdentityIncludeDescriptor> Descriptors)
    : IInclude<IdentityDestinationType, IdentityIncludeType, IdentityIncludeDescriptor>;
