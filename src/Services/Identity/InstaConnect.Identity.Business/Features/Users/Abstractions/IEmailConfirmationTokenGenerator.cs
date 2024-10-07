using InstaConnect.Identity.Business.Features.Users.Models;

namespace InstaConnect.Identity.Business.Features.Users.Abstractions;
public interface IEmailConfirmationTokenGenerator
{
    GenerateEmailConfirmationTokenResponse GenerateEmailConfirmationToken(string userId, string email);
}
