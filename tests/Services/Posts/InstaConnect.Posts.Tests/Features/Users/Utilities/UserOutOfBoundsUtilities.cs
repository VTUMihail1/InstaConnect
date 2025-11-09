namespace InstaConnect.Posts.Tests.Features.Users.Utilities;

public static class UserOutOfBoundsUtilities
{
    public static readonly int IdTooShort = IntOperations.Decrement(UserConfigurations.IdMinLength);
    public static readonly int IdTooLong = IntOperations.Increment(UserConfigurations.IdMaxLength);

    public static readonly int NameTooShort = IntOperations.Decrement(UserConfigurations.NameMinLength);
    public static readonly int NameTooLong = IntOperations.Increment(UserConfigurations.NameMaxLength);

    public static readonly int EmailTooShort = IntOperations.Decrement(UserConfigurations.EmailMinLength);
    public static readonly int EmailTooLong = IntOperations.Increment(UserConfigurations.EmailMaxLength);

    public static readonly int FirstNameTooShort = IntOperations.Decrement(UserConfigurations.FirstNameMinLength);
    public static readonly int FirstNameTooLong = IntOperations.Increment(UserConfigurations.FirstNameMaxLength);

    public static readonly int LastNameTooShort = IntOperations.Decrement(UserConfigurations.LastNameMinLength);
    public static readonly int LastNameTooLong = IntOperations.Increment(UserConfigurations.LastNameMaxLength);

    public static readonly int ProfileImageTooLong = IntOperations.Increment(UserConfigurations.ProfileImageMaxLength);
}
