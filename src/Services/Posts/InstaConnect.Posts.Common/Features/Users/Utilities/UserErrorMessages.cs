using InstaConnect.Common.Extensions;

namespace InstaConnect.Posts.Common.Features.Users.Utilities;

public static class UserErrorMessages
{
    public static string GetIdTooShort(int length)
    {
        const string Format = "Id length is {0} and it must be at least {1} characters long";
        return Format.FormatInvariant(length, UserConfigurations.IdMinLength);
    }

    public static string GetIdTooLong(int length)
    {
        const string Format = "Id length is {0} and it must be at most {1} characters long";
        return Format.FormatInvariant(length, UserConfigurations.IdMaxLength);
    }

    public static string GetEmailTooShort(int length)
    {
        const string Format = "Email length is {0} and it must be at least {1} characters long";
        return Format.FormatInvariant(length, UserConfigurations.EmailMinLength);
    }

    public static string GetEmailTooLong(int length)
    {
        const string Format = "Email length is {0} and it must be at most {1} characters long";
        return Format.FormatInvariant(length, UserConfigurations.EmailMaxLength);
    }

    public static string GetFirstNameTooShort(int length)
    {
        const string Format = "First name length is {0} and it must be at least {1} characters long";
        return Format.FormatInvariant(length, UserConfigurations.FirstNameMinLength);
    }

    public static string GetFirstNameTooLong(int length)
    {
        const string Format = "First name length is {0} and it must be at most {1} characters long";
        return Format.FormatInvariant(length, UserConfigurations.FirstNameMaxLength);
    }

    public static string GetLastNameTooShort(int length)
    {
        const string Format = "Last name length is {0} and it must be at least {1} characters long";
        return Format.FormatInvariant(length, UserConfigurations.LastNameMinLength);
    }

    public static string GetLastNameTooLong(int length)
    {
        const string Format = "Last name length is {0} and it must be at most {1} characters long";
        return Format.FormatInvariant(length, UserConfigurations.LastNameMaxLength);
    }

    public static string GetNameTooShort(int length)
    {
        const string Format = "Name length is {0} and it must be at least {1} characters long";
        return Format.FormatInvariant(length, UserConfigurations.NameMinLength);
    }

    public static string GetNameTooLong(int length)
    {
        const string Format = "Name length is {0} and it must be at most {1} characters long";
        return Format.FormatInvariant(length, UserConfigurations.NameMaxLength);
    }

    public static string GetProfileImageTooShort(int length)
    {
        const string Format = "Profile image URL length is {0} and it must be at least {1} characters long";
        return Format.FormatInvariant(length, UserConfigurations.ProfileImageMinLength);
    }

    public static string GetProfileImageTooLong(int length)
    {
        const string Format = "Profile image URL length is {0} and it must be at most {1} characters long";
        return Format.FormatInvariant(length, UserConfigurations.ProfileImageMaxLength);
    }
}
