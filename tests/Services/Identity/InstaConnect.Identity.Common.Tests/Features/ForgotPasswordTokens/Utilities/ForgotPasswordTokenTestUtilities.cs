using InstaConnect.Common.Tests.Utilities;

namespace InstaConnect.Identity.Common.Tests.Features.ForgotPasswordTokens.Utilities;

public abstract class ForgotPasswordTokenTestUtilities : DataFaker
{
    public static readonly string InvalidValue = GetAverageString(ForgotPasswordTokenConfigurations.ValueMaxLength, ForgotPasswordTokenConfigurations.ValueMaxLength);
}
