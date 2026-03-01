using InstaConnect.Identity.Domain.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenIncludeDescriptorFactory
{
    IdentityIncludeDescriptor CreateUser();
}
