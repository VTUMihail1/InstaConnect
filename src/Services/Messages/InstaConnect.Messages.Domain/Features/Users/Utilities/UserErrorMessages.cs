using InstaConnect.Common.Extensions;
using InstaConnect.Posts.Domain.Features.Users.Utilities;

namespace InstaConnect.Posts.Common.Features.Users.Utilities;

public static class UserErrorMessages
{
    public static string GetIdEmpty()
    {
        const string Message = "Id must not be empty.";

        return Message;
    }

    public static string GetIdTooShort(int length)
    {
        const string Format = "Id length is {0} and it must be at least {1} characters long";
        return Format.FormatInvariantCulture(length, UserConfigurations.IdMinLength);
    }

    public static string GetIdTooLong(int length)
    {
        const string Format = "Id length is {0} and it must be at most {1} characters long";
        return Format.FormatInvariantCulture(length, UserConfigurations.IdMaxLength);
    }

    public static string GetEmailEmpty()
    {
        const string Message = "Email must not be empty.";

        return Message;
    }

    public static string GetEmailTooShort(int length)
    {
        const string Format = "Email length is {0} and it must be at least {1} characters long";
        return Format.FormatInvariantCulture(length, UserConfigurations.EmailMinLength);
    }

    public static string GetEmailTooLong(int length)
    {
        const string Format = "Email length is {0} and it must be at most {1} characters long";
        return Format.FormatInvariantCulture(length, UserConfigurations.EmailMaxLength);
    }

    public static string GetFirstNameEmpty()
    {
        const string Message = "First name must not be empty.";

        return Message;
    }
    
    public static string GetFirstNameTooShort(int length)
    {
        const string Format = "First name length is {0} and it must be at least {1} characters long";
        return Format.FormatInvariantCulture(length, UserConfigurations.FirstNameMinLength);
    }

    public static string GetFirstNameTooLong(int length)
    {
        const string Format = "First name length is {0} and it must be at most {1} characters long";
        return Format.FormatInvariantCulture(length, UserConfigurations.FirstNameMaxLength);
    }

    public static string GetLastNameEmpty()
    {
        const string Message = "Last name must not be empty.";

        return Message;
    }

    public static string GetLastNameTooShort(int length)
    {
        const string Format = "Last name length is {0} and it must be at least {1} characters long";
        return Format.FormatInvariantCulture(length, UserConfigurations.LastNameMinLength);
    }

    public static string GetLastNameTooLong(int length)
    {
        const string Format = "Last name length is {0} and it must be at most {1} characters long";
        return Format.FormatInvariantCulture(length, UserConfigurations.LastNameMaxLength);
    }

    public static string GetNameEmpty()
    {
        const string Message = "Name must not be empty.";

        return Message;
    }

    public static string GetNameTooShort(int length)
    {
        const string Format = "Name length is {0} and it must be at least {1} characters long";
        return Format.FormatInvariantCulture(length, UserConfigurations.NameMinLength);
    }

    public static string GetNameTooLong(int length)
    {
        const string Format = "Name length is {0} and it must be at most {1} characters long";
        return Format.FormatInvariantCulture(length, UserConfigurations.NameMaxLength);
    }

    public static string GetProfileImageTooLong(int length)
    {
        const string Format = "Profile image URL length is {0} and it must be at most {1} characters long";
        return Format.FormatInvariantCulture(length, UserConfigurations.ProfileImageMaxLength);
    }
}
