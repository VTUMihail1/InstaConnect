namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Helpers;

public class ForgotPasswordTokenIncludeBuilder
{
    private readonly HashSet<ForgotPasswordTokenIncludeProperty> _includeProperties;

    internal ForgotPasswordTokenIncludeBuilder(ICollection<ForgotPasswordTokenIncludeProperty> includeProperties)
    {
        _includeProperties = [.. includeProperties];
    }

    public ForgotPasswordTokenInclude Build()
    {
        return new(_includeProperties);
    }
}
