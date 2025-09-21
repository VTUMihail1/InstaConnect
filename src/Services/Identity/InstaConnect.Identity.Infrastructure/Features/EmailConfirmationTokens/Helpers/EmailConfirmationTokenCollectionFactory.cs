using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Response;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;
using InstaConnect.Users.Domain.Features.Users.Models.Responses;

namespace InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Helpers;

internal class EmailConfirmationTokenCollectionFactory : IEmailConfirmationTokenCollectionFactory
{
    public EmailConfirmationTokenCollection Create(ICollection<EmailConfirmationToken> emailConfirmationToken)
    {
        return new EmailConfirmationTokenCollection(emailConfirmationToken);
    }
}
