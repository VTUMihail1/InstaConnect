using InstaConnect.Identity.Business.Features.Users.Models;

namespace InstaConnect.Identity.Business.Features.Users.Abstractions;
public interface IForgotPasswordTokenGenerator
{
    GenerateForgotPasswordTokenResponse GenerateForgotPasswordToken(string userId, string email);
}
