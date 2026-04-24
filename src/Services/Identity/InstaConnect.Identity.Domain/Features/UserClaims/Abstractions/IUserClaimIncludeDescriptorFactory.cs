using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

public interface IUserClaimIncludeDescriptorFactory
{
    IdentityIncludeDescriptor CreateUser();
}
