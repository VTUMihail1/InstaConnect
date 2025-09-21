using InstaConnect.ForgotPasswordTokens.Infrastructure.Features.ForgotPasswordTokens.Models;
using InstaConnect.Users.Infrastructure.Features.Users.Models;

namespace InstaConnect.ForgotPasswordTokens.Infrastructure.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenQuerySql
{
    public const string GetById = $@"SELECT
                                       fpt.id AS {nameof(ForgotPasswordTokenQueryEntity.Id)},
                                       fpt.value AS {nameof(ForgotPasswordTokenQueryEntity.Value)},
                                       fpt.expires_at AS {nameof(ForgotPasswordTokenQueryEntity.ExpiresAt)},
                                       fpt.created_at AS {nameof(ForgotPasswordTokenQueryEntity.CreatedAt)},
                                       fpt.updated_at AS {nameof(ForgotPasswordTokenQueryEntity.UpdatedAt)},
                                   FROM forgot_password_tokens fpt
                                   WHERE fpt.{nameof(ForgotPasswordTokenQueryEntity.Id)} = @{nameof(GetForgotPasswordTokenByIdQueryParameters.Id)}
                                   AND fpt.{nameof(GetForgotPasswordTokenByIdQueryParameters.Value)} = @{nameof(GetForgotPasswordTokenByIdQueryParameters.Value)};";
}
