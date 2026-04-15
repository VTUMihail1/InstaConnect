namespace InstaConnect.Identity.Domain.Models.Requests;

public record IdentityIncludeDescriptor(
    IdentityDestinationType DestinationType,
    IdentityIncludeType IncludeType)
    : IIncludeDescriptor<IdentityDestinationType, IdentityIncludeType>;
