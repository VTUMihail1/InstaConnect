using InstaConnect.Common.Extensions;

namespace InstaConnect.Posts.Common.Features.Users.Utilities;

public static class UserErrorMessages
{
    public static string GetIdTooShort(string id)
    {
        const string Format = "Id length is {0} and it must be at least {1} characters long";
        return Format.FormatInvariant(id.GetLength(), UserConfigurations.IdMinLength);
    }

    public static string GetIdTooLong(string id)
    {
        const string Format = "Id length is {0} and it must be at most {1} characters long";
        return Format.FormatInvariant(id.GetLength(), UserConfigurations.IdMaxLength);
    }

    public static string GetEmailTooShort(string email)
    {
        const string Format = "Email length is {0} and it must be at least {1} characters long";
        return Format.FormatInvariant(email.GetLength(), UserConfigurations.EmailMinLength);
    }

    public static string GetEmailTooLong(string email)
    {
        const string Format = "Email length is {0} and it must be at most {1} characters long";
        return Format.FormatInvariant(email.GetLength(), UserConfigurations.EmailMaxLength);
    }

    public static string GetFirstNameTooShort(string firstName)
    {
        const string Format = "First name length is {0} and it must be at least {1} characters long";
        return Format.FormatInvariant(firstName.GetLength(), UserConfigurations.FirstNameMinLength);
    }

    public static string GetFirstNameTooLong(string firstName)
    {
        const string Format = "First name length is {0} and it must be at most {1} characters long";
        return Format.FormatInvariant(firstName.GetLength(), UserConfigurations.FirstNameMaxLength);
    }

    public static string GetLastNameTooShort(string lastName)
    {
        const string Format = "Last name length is {0} and it must be at least {1} characters long";
        return Format.FormatInvariant(lastName.GetLength(), UserConfigurations.LastNameMinLength);
    }

    public static string GetLastNameTooLong(string lastName)
    {
        const string Format = "Last name length is {0} and it must be at most {1} characters long";
        return Format.FormatInvariant(lastName.GetLength(), UserConfigurations.LastNameMaxLength);
    }

    public static string GetNameTooShort(string name)
    {
        const string Format = "Name length is {0} and it must be at least {1} characters long";
        return Format.FormatInvariant(name.GetLength(), UserConfigurations.NameMinLength);
    }

    public static string GetNameTooLong(string name)
    {
        const string Format = "Name length is {0} and it must be at most {1} characters long";
        return Format.FormatInvariant(name.GetLength(), UserConfigurations.NameMaxLength);
    }

    public static string GetProfileImageTooShort(string imageUrl)
    {
        const string Format = "Profile image URL length is {0} and it must be at least {1} characters long";
        return Format.FormatInvariant(imageUrl.GetLength(), UserConfigurations.ProfileImageMinLength);
    }

    public static string GetProfileImageTooLong(string imageUrl)
    {
        const string Format = "Profile image URL length is {0} and it must be at most {1} characters long";
        return Format.FormatInvariant(imageUrl.GetLength(), UserConfigurations.ProfileImageMaxLength);
    }
}
