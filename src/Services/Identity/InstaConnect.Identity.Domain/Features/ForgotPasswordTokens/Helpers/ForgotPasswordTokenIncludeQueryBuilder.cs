using InstaConnect.ForgotPasswordTokens.Domain.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.UserClaims.Domain.Features.UserClaims.Abstractions;
using InstaConnect.UserClaims.Domain.Features.UserClaims.Models.Requests;

namespace InstaConnect.UserClaims.Domain.Features.UserClaims.Helpers;

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
