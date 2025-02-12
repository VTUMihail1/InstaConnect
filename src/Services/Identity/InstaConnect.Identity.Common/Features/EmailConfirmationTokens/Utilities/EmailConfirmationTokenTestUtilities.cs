using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Common.Features.EmailConfirmationTokens.Utilities;

public abstract class EmailConfirmationTokenTestUtilities : SharedTestUtilities
{
    public static readonly string InvalidValue = GetAverageString(EmailConfirmationTokenConfigurations.ValueMaxLength, EmailConfirmationTokenConfigurations.ValueMaxLength);
}
