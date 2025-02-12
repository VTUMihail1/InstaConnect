using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Models;

namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Abstractions;
public interface IEmailConfirmationTokenGenerator
{
    GenerateEmailConfirmationTokenResponse GenerateEmailConfirmationToken(string userId, string email);
}
