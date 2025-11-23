using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Chats.Domain.Features.Users.Utilities;

public static class UserExceptionErrorMessages
{
    public static string GetNotFoundMessage(UserId id)
    {
        const string Format = "User(id: {0}) does not exist";

        return Format.FormatCurrentCulture(id.Id);
    }

    public static string GetAlreadyExistsMessage(UserId id)
    {
        const string Format = "User(id: {0}) already exists";

        return Format.FormatCurrentCulture(id.Id);
    }

    public static string GetNameAlreadyExistsMessage(Name name)
    {
        const string Format = "User(name: {0}) already exists";

        return Format.FormatCurrentCulture(name.Value);
    }

    public static string GetEmailAlreadyExistsMessage(Email email)
    {
        const string Format = "User(email: {0}) already exists";

        return Format.FormatCurrentCulture(email.Value);
    }

    public static string GetInclidePropertyNotSupportedMessage(ICollection<UserIncludeProperty> includeProperties)
    {
        const string Format = "UserIncludeProperties(types: {0}) is not supported";

        return Format.FormatCurrentCulture(includeProperties.JoinAsStringWithComa());
    }
}
