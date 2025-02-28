namespace InstaConnect.Identity.Common.Tests.Features.ForgotPasswordTokens.Utilities;

public abstract class ForgotPasswordTokenTestUtilities : SharedTestUtilities
{
    public static readonly string InvalidValue = GetAverageString(ForgotPasswordTokenConfigurations.ValueMaxLength, ForgotPasswordTokenConfigurations.ValueMaxLength);
}
