using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Users.Infrastructure.Utilities;
public static class IdentityCollectionNames
{
    public const string Users = "users";

    public const string UserClaims = "user_claims";

    public const string RefreshTokens = "refresh_tokens";

    public const string ForgotPasswordTokens = "forgot_password_tokens";

    public const string EmailConfirmationTokens = "email_confirmation_tokens";
}
