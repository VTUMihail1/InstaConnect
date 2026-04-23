using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.Users.Abstractions;

public interface IUserIncludeDescriptorFactory
{
    IdentityIncludeDescriptor CreateUserClaims();

    IdentityIncludeDescriptor CreateRefreshTokens();

    IdentityIncludeDescriptor CreateForgotPasswordTokens();

    IdentityIncludeDescriptor CreateEmailConfirmationTokens();
}
