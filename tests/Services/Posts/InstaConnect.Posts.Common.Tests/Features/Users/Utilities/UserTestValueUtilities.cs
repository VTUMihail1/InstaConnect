using InstaConnect.Common.Extensions;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;

public static class UserTestValueUtilities
{
    public static readonly int IdAverage = IntOperations.Average(UserConfigurations.IdMaxLength, UserConfigurations.IdMinLength);
    public static readonly int IdTooShort = IntOperations.Decrement(UserConfigurations.IdMinLength);
    public static readonly int IdTooLong = IntOperations.Increment(UserConfigurations.IdMaxLength);

    public static readonly int NameTooShort = IntOperations.Decrement(UserConfigurations.NameMinLength);
    public static readonly int NameTooLong = IntOperations.Increment(UserConfigurations.NameMaxLength);
}
