namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Helpers;

public class ForgotPasswordTokenIncludeQueryBuilderFactory : IForgotPasswordTokenIncludeQueryBuilderFactory
{
    public ForgotPasswordTokenIncludeQueryBuilder Create()
    {
        return new ForgotPasswordTokenIncludeQueryBuilder([]);
    }
}
