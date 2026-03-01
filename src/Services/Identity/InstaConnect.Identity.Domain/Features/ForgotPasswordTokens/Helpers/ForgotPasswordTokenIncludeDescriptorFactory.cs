using InstaConnect.Identity.Domain.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Helpers;

public class ForgotPasswordTokenIncludeDescriptorFactory : IForgotPasswordTokenIncludeDescriptorFactory
{
    public IdentityIncludeDescriptor CreateUser()
    {
        return new(IdentityDestinationType.ForgotPasswordTokens, IdentityIncludeType.Users);
    }
}
