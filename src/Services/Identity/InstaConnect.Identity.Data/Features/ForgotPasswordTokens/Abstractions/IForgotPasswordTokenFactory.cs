using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Models.Entitites;

namespace InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Abstractions;
public interface IForgotPasswordTokenFactory
{
    ForgotPasswordToken GetForgotPasswordToken(string userId);
}