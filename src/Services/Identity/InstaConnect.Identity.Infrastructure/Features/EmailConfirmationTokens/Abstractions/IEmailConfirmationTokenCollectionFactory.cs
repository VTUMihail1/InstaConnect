using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Response;
using InstaConnect.Users.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;
internal interface IEmailConfirmationTokenCollectionFactory
{
    EmailConfirmationTokenCollection Create(ICollection<EmailConfirmationToken> userClaims);
}
