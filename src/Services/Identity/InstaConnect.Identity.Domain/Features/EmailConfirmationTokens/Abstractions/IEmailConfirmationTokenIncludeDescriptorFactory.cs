using InstaConnect.Identity.Domain.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenIncludeDescriptorFactory
{
    IdentityIncludeDescriptor CreateUser();
}
