using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Helpers;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;

public interface IForgotPasswordTokenIncludeQueryBuilderFactory
{
    ForgotPasswordTokenIncludeQueryBuilder Create();
}
