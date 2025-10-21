using InstaConnect.ForgotPasswordTokens.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.UserClaims.Domain.Features.UserClaims.Abstractions;

namespace InstaConnect.UserClaims.Domain.Features.UserClaims.Helpers;

public class ForgotPasswordTokenIncludeQueryBuilderFactory : IForgotPasswordTokenIncludeQueryBuilderFactory
{
    public ForgotPasswordTokenIncludeQueryBuilder Create()
    {
        return new ForgotPasswordTokenIncludeQueryBuilder([]);
    }
}
