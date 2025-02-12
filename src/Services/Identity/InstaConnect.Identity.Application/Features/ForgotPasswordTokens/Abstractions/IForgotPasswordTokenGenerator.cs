using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Models;

namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Abstractions;
public interface IForgotPasswordTokenGenerator
{
    GenerateForgotPasswordTokenResponse GenerateForgotPasswordToken(string userId, string email);
}
