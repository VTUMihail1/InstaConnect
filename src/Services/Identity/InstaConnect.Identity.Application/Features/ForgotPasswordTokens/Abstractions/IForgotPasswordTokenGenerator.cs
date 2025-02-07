using InstaConnect.Identity.Application.Features.Users.Models;

namespace InstaConnect.Identity.Application.Features.Users.Abstractions;
public interface IForgotPasswordTokenGenerator
{
    GenerateForgotPasswordTokenResponse GenerateForgotPasswordToken(string userId, string email);
}
