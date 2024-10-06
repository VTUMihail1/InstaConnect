using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Models.Entitites;

namespace InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Abstractions;
public interface IEmailConfirmationTokenFactory
{
    EmailConfirmationToken GetEmailConfirmationToken(string userId);
}