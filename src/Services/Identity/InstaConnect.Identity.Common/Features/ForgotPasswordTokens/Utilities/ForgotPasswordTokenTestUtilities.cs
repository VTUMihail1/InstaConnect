using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Common.Features.ForgotPasswordTokens.Utilities;

public abstract class ForgotPasswordTokenTestUtilities : SharedTestUtilities
{
    public static readonly string InvalidValue = GetAverageString(ForgotPasswordTokenConfigurations.ValueMaxLength, ForgotPasswordTokenConfigurations.ValueMaxLength);
}
