using InstaConnect.Common.Extensions;
using InstaConnect.Posts.Domain.Features.Users.Utilities;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

public static class UserOutOfBoundUtilities
{
    public static readonly int IdTooShort = UserConfigurations.IdMinLength.Decrement();
    public static readonly int IdTooLong = UserConfigurations.IdMaxLength.Increment();

    public static readonly int EmailTooShort = UserConfigurations.EmailMinLength.Decrement();
    public static readonly int EmailTooLong = UserConfigurations.EmailMaxLength.Increment();

    public static readonly int FirstNameTooShort = UserConfigurations.FirstNameMinLength.Decrement();
    public static readonly int FirstNameTooLong = UserConfigurations.FirstNameMaxLength.Increment();

    public static readonly int LastNameTooShort = UserConfigurations.LastNameMinLength.Decrement();
    public static readonly int LastNameTooLong = UserConfigurations.LastNameMaxLength.Increment();

    public static readonly int NameTooShort = UserConfigurations.NameMinLength.Decrement();
    public static readonly int NameTooLong = UserConfigurations.NameMaxLength.Increment();

    public static readonly int ProfileImageTooShort = UserConfigurations.ProfileImageMinLength.Decrement();
    public static readonly int ProfileImageTooLong = UserConfigurations.ProfileImageMaxLength.Increment();
}
