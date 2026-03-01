using InstaConnect.Identity.Domain.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.Users.Helpers;

public class UserIncludeDescriptorFactory : IUserIncludeDescriptorFactory
{
    public IdentityIncludeDescriptor CreateUserClaims()
    {
        return new(IdentityDestinationType.Users, IdentityIncludeType.UserClaims);
    }

    public IdentityIncludeDescriptor CreateRefreshTokens()
    {
        return new(IdentityDestinationType.Users, IdentityIncludeType.RefreshTokens);
    }

    public IdentityIncludeDescriptor CreateForgotPasswordTokens()
    {
        return new(IdentityDestinationType.Users, IdentityIncludeType.ForgotPasswordTokens);
    }

    public IdentityIncludeDescriptor CreateEmailConfirmationTokens()
    {
        return new(IdentityDestinationType.Users, IdentityIncludeType.EmailConfirmationTokens);
    }
}
