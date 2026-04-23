using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;

public record ForgotPasswordTokenInclude(ICollection<IdentityIncludeDescriptor> Descriptors)
    : IInclude<IdentityDestinationType, IdentityIncludeType, IdentityIncludeDescriptor>;
