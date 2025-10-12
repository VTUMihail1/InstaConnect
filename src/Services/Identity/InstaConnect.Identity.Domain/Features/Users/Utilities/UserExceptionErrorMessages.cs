using InstaConnect.Common.Extensions;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.Users.Utilities;

public static class UserExceptionErrorMessages
{
    public static string GetNotFoundMessage(string id)
    {
        const string Format = "User(id: {0}) does not exist";
        var result = Format.FormatCurrentCulture(id);

        return result;
    }

    public static string GetEmailNotFoundMessage(string email)
    {
        const string Format = "User(email: {0}) does not exist";
        var result = Format.FormatCurrentCulture(email);

        return result;
    }

    public static string GetNameAlreadyTakenMessage(string name)
    {
        const string Format = "User(name: {0}) already taken";
        var result = Format.FormatCurrentCulture(name);

        return result;
    }

    public static string GetEmailAlreadyTakenMessage(string email)
    {
        const string Format = "User(email: {0}) already taken";
        var result = Format.FormatCurrentCulture(email);

        return result;
    }

    public static string GetEmailAlreadyConfirmedMessage(string email)
    {
        const string Format = "User(email: {0}) already confirmed";
        var result = Format.FormatCurrentCulture(email);

        return result;
    }

    public static string GetEmailNotConfirmedMessage(string email)
    {
        const string Format = "User(email: {0}) not confirmed";
        var result = Format.FormatCurrentCulture(email);

        return result;
    }

    public static string GetInvalidDetailsMessage(string name)
    {
        const string Format = "User(name: {0}) has invalid details";
        var result = Format.FormatCurrentCulture(name);

        return result;
    }

    public static string GetSortPropertyNotSupportedMessage(UserSortProperty sortProperty)
    {
        const string Format = "PostSortProperty(type: {0}) is not supported";
        var result = Format.FormatCurrentCulture(sortProperty);

        return result;
    }
}
