namespace InstaConnect.Posts.Common.Features.Users.Utilities;

public static class UserErrorMessages
{
    public static readonly string IdEmpty = $"Id must not be empty.";
    public static readonly string IdTooShort = $"Id must be at least {UserConfigurations.IdMinLength} characters long.";
    public static readonly string IdTooLong = $"Id must be at most {UserConfigurations.IdMaxLength} characters long.";

    public static readonly string EmailEmpty = $"Email must not be empty.";
    public static readonly string EmailTooShort = $"Email must be at least {UserConfigurations.EmailMinLength} characters long.";
    public static readonly string EmailTooLong = $"Email must be at most {UserConfigurations.EmailMaxLength} characters long.";

    public static readonly string FirstNameEmpty = $"First name must not be empty.";
    public static readonly string FirstNameTooShort = $"First name must be at least {UserConfigurations.FirstNameMinLength} characters long.";
    public static readonly string FirstNameTooLong = $"First name must be at most {UserConfigurations.FirstNameMaxLength} characters long.";

    public static readonly string LastNameEmpty = $"Last name must not be empty.";
    public static readonly string LastNameTooShort = $"Last name must be at least {UserConfigurations.LastNameMinLength} characters long.";
    public static readonly string LastNameTooLong = $"Last name must be at most {UserConfigurations.LastNameMaxLength} characters long.";

    public static readonly string NameEmpty = $"Name must not be empty.";
    public static readonly string NameTooShort = $"Name must be at least {UserConfigurations.NameMinLength} characters long.";
    public static readonly string NameTooLong = $"Name must be at most {UserConfigurations.NameMaxLength} characters long.";

    public static readonly string ProfileImageEmpty = $"Profile image URL must not be empty.";
    public static readonly string ProfileImageTooShort = $"Profile image URL must be at least {UserConfigurations.ProfileImageMinLength} characters long.";
    public static readonly string ProfileImageTooLong = $"Profile image URL must be at most {UserConfigurations.ProfileImageMaxLength} characters long.";
}
