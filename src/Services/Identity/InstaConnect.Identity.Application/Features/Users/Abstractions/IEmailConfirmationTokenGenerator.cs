using InstaConnect.Identity.Application.Features.Users.Models;

namespace InstaConnect.Identity.Application.Features.Users.Abstractions;
public interface IEmailConfirmationTokenGenerator
{
    GenerateEmailConfirmationTokenResponse GenerateEmailConfirmationToken(string userId, string email);
}
