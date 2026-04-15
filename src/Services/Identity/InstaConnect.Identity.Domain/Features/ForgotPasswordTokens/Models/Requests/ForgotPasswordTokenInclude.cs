using InstaConnect.Identity.Domain.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;

public record ForgotPasswordTokenInclude(ICollection<IdentityIncludeDescriptor> Descriptors)
    : IInclude<IdentityDestinationType, IdentityIncludeType, IdentityIncludeDescriptor>;
