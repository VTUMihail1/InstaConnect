using InstaConnect.ForgotPasswordTokens.Domain.Features.ForgotPasswordTokens.Helpers;
using InstaConnect.UserClaims.Domain.Features.UserClaims.Helpers;

namespace InstaConnect.ForgotPasswordTokens.Domain.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenIncludeQueryBuilderFactory
{
    ForgotPasswordTokenIncludeQueryBuilder Create();
}
