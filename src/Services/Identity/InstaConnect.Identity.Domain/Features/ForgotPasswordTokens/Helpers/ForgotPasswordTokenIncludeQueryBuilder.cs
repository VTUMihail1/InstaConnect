using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Helpers;

public class ForgotPasswordTokenIncludeQueryBuilder
{
    private readonly ICollection<ForgotPasswordTokenIncludeProperty> _includeProperties;

    internal ForgotPasswordTokenIncludeQueryBuilder(ICollection<ForgotPasswordTokenIncludeProperty> includeProperties)
    {
        _includeProperties = includeProperties;
    }

    public CommonIncludeQuery<ForgotPasswordTokenIncludeProperty> Build()
    {
        return new(_includeProperties);
    }
}
