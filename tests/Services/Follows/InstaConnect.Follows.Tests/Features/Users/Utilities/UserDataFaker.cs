namespace InstaConnect.Follows.Tests.Features.Users.Utilities;

public static class UserDataFaker
{
    public static string GetId()
    {
        return DataFaker.GetAverageString(UserConfigurations.IdMaxLength, UserConfigurations.IdMinLength);
    }

    public static string GetName()
    {
        return DataFaker.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength);
    }

    public static string GetNameWithPrefix(string name)
    {
        return DataFaker.GetAverageWithPrefixString(name, UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength);
    }

    public static string GetFirstName()
    {
        return DataFaker.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength);
    }

    public static string GetFirstNameWithPrefix(string firstName)
    {
        return DataFaker.GetAverageWithPrefixString(firstName, UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength);
    }

    public static string GetLastName()
    {
        return DataFaker.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength);
    }

    public static string GetLastNameWithPrefix(string lastName)
    {
        return DataFaker.GetAverageWithPrefixString(lastName, UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength);
    }

    public static string GetEmail()
    {
        return DataFaker.GetEmail(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength);
    }

    public static string GetEmailWithPrefix(string email)
    {
        return DataFaker.GetAverageWithPrefixString(email, UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength);
    }

    public static string GetProfileImage()
    {
        return DataFaker.GetAverageString(UserConfigurations.ProfileImageUrlMaxLength);
    }

    public static DateTimeOffset GetCreatedAtUtc()
    {
        return DataFaker.GetRecentDate();
    }

    public static DateTimeOffset GetUpdatedAtUtc()
    {
        return DataFaker.GetRecentDate();
    }
}
