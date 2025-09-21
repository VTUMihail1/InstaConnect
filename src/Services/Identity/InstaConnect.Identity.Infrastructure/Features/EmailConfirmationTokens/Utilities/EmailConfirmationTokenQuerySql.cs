using InstaConnect.EmailConfirmationTokens.Infrastructure.Features.EmailConfirmationTokens.Models;
using InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Models;
using InstaConnect.Users.Infrastructure.Features.Users.Models;

namespace InstaConnect.EmailConfirmationTokens.Infrastructure.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenQuerySql
{

    public const string GetAll = $@"SELECT 
                                       ect.id AS {nameof(EmailConfirmationTokenQueryEntity.Id)},
                                       ect.value AS {nameof(EmailConfirmationTokenQueryEntity.Value)},
                                       ect.expires_at AS {nameof(EmailConfirmationTokenQueryEntity.ExpiresAt)},
                                       ect.created_at AS {nameof(EmailConfirmationTokenQueryEntity.CreatedAt)},
                                       ect.updated_at AS {nameof(EmailConfirmationTokenQueryEntity.UpdatedAt)},
                                   FROM email_confirmation_tokens ect
                                   WHERE ect.{nameof(EmailConfirmationTokenQueryEntity.Id)} = @{nameof(GetAllEmailConfirmationTokensQueryParameters.Id)};";

    public const string GetById = $@"SELECT
                                       ect.id AS {nameof(EmailConfirmationTokenQueryEntity.Id)},
                                       ect.value AS {nameof(EmailConfirmationTokenQueryEntity.Value)},
                                       ect.expires_at AS {nameof(EmailConfirmationTokenQueryEntity.ExpiresAt)},
                                       ect.created_at AS {nameof(EmailConfirmationTokenQueryEntity.CreatedAt)},
                                       ect.updated_at AS {nameof(EmailConfirmationTokenQueryEntity.UpdatedAt)},
                                   FROM email_confirmation_tokens ect
                                   WHERE ect.{nameof(EmailConfirmationTokenQueryEntity.Id)} = @{nameof(GetEmailConfirmationTokenByIdQueryParameters.Id)}
                                   AND ect.{nameof(EmailConfirmationTokenQueryEntity.Value)} = @{nameof(GetEmailConfirmationTokenByIdQueryParameters.Value)};";
}
