using InstaConnect.Identity.Common.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Shared.Common.Models.Enums;
using InstaConnect.Shared.Common.Utilities;
using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Common.Features.Users.Utilities;

public abstract class ForgotPasswordTokenTestUtilities : SharedTestUtilities
{
    public static readonly string InvalidValue = GetAverageString(ForgotPasswordTokenConfigurations.ValueMaxLength, ForgotPasswordTokenConfigurations.ValueMaxLength);
}
