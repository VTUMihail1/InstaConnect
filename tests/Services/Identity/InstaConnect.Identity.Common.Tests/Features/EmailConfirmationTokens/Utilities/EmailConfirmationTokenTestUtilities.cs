namespace InstaConnect.Identity.Common.Tests.Features.EmailConfirmationTokens.Utilities;

public abstract class EmailConfirmationTokenTestUtilities : SharedTestUtilities
{
    public static readonly string InvalidValue = GetAverageString(EmailConfirmationTokenConfigurations.ValueMaxLength, EmailConfirmationTokenConfigurations.ValueMaxLength);
}
