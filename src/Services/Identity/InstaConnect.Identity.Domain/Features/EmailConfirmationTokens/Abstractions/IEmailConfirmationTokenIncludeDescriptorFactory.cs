using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;

public interface IEmailConfirmationTokenIncludeDescriptorFactory
{
    IdentityIncludeDescriptor CreateUser();
}
