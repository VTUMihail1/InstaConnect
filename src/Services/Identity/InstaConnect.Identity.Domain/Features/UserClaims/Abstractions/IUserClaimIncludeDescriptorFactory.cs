using InstaConnect.Identity.Domain.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

public interface IUserClaimIncludeDescriptorFactory
{
    IdentityIncludeDescriptor CreateUser();
}
