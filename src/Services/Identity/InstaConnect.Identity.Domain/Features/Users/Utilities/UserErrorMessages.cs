using InstaConnect.Common.Extensions;
using InstaConnect.Identity.Domain.Features.Users.Utilities;

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
        return Format.FormatCurrentCulture(length, UserConfigurations.IdMinLength);
    }

    public static string GetIdTooLong(int length)
    {
        const string Format = "Id length is {0} and it must be at most {1} characters long";
        return Format.FormatCurrentCulture(length, UserConfigurations.IdMaxLength);
    }

    public static string GetEmailEmpty()
    {
        const string Message = "Email must not be empty.";

        return Message;
    }

    public static string GetEmailTooShort(int length)
    {
        const string Format = "Email length is {0} and it must be at least {1} characters long";
        return Format.FormatCurrentCulture(length, UserConfigurations.EmailMinLength);
    }

    public static string GetEmailTooLong(int length)
    {
        const string Format = "Email length is {0} and it must be at most {1} characters long";
        return Format.FormatCurrentCulture(length, UserConfigurations.EmailMaxLength);
    }

    public static string GetFirstNameEmpty()
    {
        const string Message = "First name must not be empty.";

        return Message;
    }
    
    public static string GetFirstNameTooShort(int length)
    {
        const string Format = "First name length is {0} and it must be at least {1} characters long";
        return Format.FormatCurrentCulture(length, UserConfigurations.FirstNameMinLength);
    }

    public static string GetFirstNameTooLong(int length)
    {
        const string Format = "First name length is {0} and it must be at most {1} characters long";
        return Format.FormatCurrentCulture(length, UserConfigurations.FirstNameMaxLength);
    }

    public static string GetLastNameEmpty()
    {
        const string Message = "Last name must not be empty.";

        return Message;
    }

    public static string GetLastNameTooShort(int length)
    {
        const string Format = "Last name length is {0} and it must be at least {1} characters long";
        return Format.FormatCurrentCulture(length, UserConfigurations.LastNameMinLength);
    }

    public static string GetLastNameTooLong(int length)
    {
        const string Format = "Last name length is {0} and it must be at most {1} characters long";
        return Format.FormatCurrentCulture(length, UserConfigurations.LastNameMaxLength);
    }

    public static string GetNameEmpty()
    {
        const string Message = "Name must not be empty.";

        return Message;
    }

    public static string GetNameTooShort(int length)
    {
        const string Format = "Name length is {0} and it must be at least {1} characters long";
        return Format.FormatCurrentCulture(length, UserConfigurations.NameMinLength);
    }

    public static string GetNameTooLong(int length)
    {
        const string Format = "Name length is {0} and it must be at most {1} characters long";
        return Format.FormatCurrentCulture(length, UserConfigurations.NameMaxLength);
    }

    public static string GetPasswordEmpty()
    {
        const string Message = "Password must not be empty.";

        return Message;
    }

    public static string GetPasswordTooShort(int length)
    {
        const string Format = "Password length is {0} and it must be at least {1} characters long";
        return Format.FormatCurrentCulture(length, UserConfigurations.PasswordMinLength);
    }

    public static string GetPasswordTooLong(int length)
    {
        const string Format = "Password length is {0} and it must be at most {1} characters long";
        return Format.FormatCurrentCulture(length, UserConfigurations.PasswordMaxLength);
    }

    public static string GetConfirmPasswordNotEqualsPassword()
    {
        const string Message = "Confirm Password needs to be the same as Password";

        return Message;
    }

    public static string GetProfileImageTooLong(int length)
    {
        const string Format = "Profile image URL length is {0} and it must be at most {1} characters long";
        return Format.FormatCurrentCulture(length, UserConfigurations.ProfileImageMaxLength);
    }

    public static string GetSortPropertyEmpty()
    {
        const string Message = "Sort property must not be empty.";

        return Message;
    }

    public static string GetPageEmpty()
    {
        const string Message = "Page must not be empty.";

        return Message;
    }

    public static string GetPageTooSmall(int page)
    {
        const string Format = "Page value is {0} and it must be at least {1}";
        var result = Format.FormatCurrentCulture(page, UserConfigurations.PageMinValue);

        return result;
    }

    public static string GetPageTooLarge(int page)
    {
        const string Format = "Page value is {0} and it must be at most {1}";
        var result = Format.FormatCurrentCulture(page, UserConfigurations.PageMaxValue);

        return result;
    }

    public static string GetPageSizeEmpty()
    {
        const string Message = "Page size must not be empty.";

        return Message;
    }

    public static string GetPageSizeTooSmall(int pageSize)
    {
        const string Format = "Page size is {0} and it must be at least {1}";
        var result = Format.FormatCurrentCulture(pageSize, UserConfigurations.PageSizeMinValue);

        return result;
    }

    public static string GetPageSizeTooLarge(int pageSize)
    {
        const string Format = "Page size is {0} and it must be at most {1}";
        var result = Format.FormatCurrentCulture(pageSize, UserConfigurations.PageSizeMaxValue);

        return result;
    }
}
