using InstaConnect.Identity.Common.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Shared.Common.Models.Enums;
using InstaConnect.Shared.Common.Utilities;
using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Common.Features.Users.Utilities;

public abstract class EmailConfirmationTokenTestUtilities : SharedTestUtilities
{
    public static readonly string InvalidValue = GetAverageString(EmailConfirmationTokenConfigurations.ValueMaxLength, EmailConfirmationTokenConfigurations.ValueMaxLength);
}
