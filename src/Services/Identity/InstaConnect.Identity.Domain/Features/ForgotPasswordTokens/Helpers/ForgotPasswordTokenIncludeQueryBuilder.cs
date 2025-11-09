namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Helpers;

public class ForgotPasswordTokenIncludeQueryBuilder
{
    private readonly ICollection<ForgotPasswordTokenIncludeProperty> _includeProperties;

    internal ForgotPasswordTokenIncludeQueryBuilder(ICollection<ForgotPasswordTokenIncludeProperty> includeProperties)
    {
        _includeProperties = includeProperties;
    }

    public ForgotPasswordTokenIncludeQuery Build()
    {
        return new ForgotPasswordTokenIncludeQuery(_includeProperties);
    }
}
