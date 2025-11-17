using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenExceptionErrorMessages
{
    public static string GetNotFoundMessage(EmailConfirmationTokenId id)
    {
        const string Format = "EmailConfirmationToken(id: {0}, value: {1}) does not exist";

        return Format.FormatCurrentCulture(id.Id.Id, id.Value);
    }

    public static string GetExpiredMessage(EmailConfirmationTokenId id)
    {
        const string Format = "EmailConfirmationToken(id: {0}, value: {1}) has expired";

        return Format.FormatCurrentCulture(id.Id.Id, id.Value);
    }

    public static string GetInclidePropertyNotSupportedMessage(ICollection<EmailConfirmationTokenIncludeProperty> includeProperties)
    {
        const string Format = "EmailConfirmationTokenIncludeProperties(types: {0}) is not supported";

        return Format.FormatCurrentCulture(includeProperties.JoinAsStringWithComa());
    }
}
