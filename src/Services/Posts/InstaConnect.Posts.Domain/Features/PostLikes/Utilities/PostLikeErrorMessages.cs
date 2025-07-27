using InstaConnect.Common.Extensions;

namespace InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;

public static class PostLikeErrorMessages
{
    public static string GetIdEmpty()
    {
        const string Message = "Id must not be empty.";

        return Message;
    }

    public static string GetIdTooShort(int length)
    {
        const string Format = "Id length is {0} and it must be at least {1} characters long";
        var result = Format.FormatInvariantCulture(length, PostLikeConfigurations.IdMinLength);

        return result;
    }

    public static string GetIdTooLong(int length)
    {
        const string Format = "Id length is {0} and it must be at most {1} characters long";
        var result = Format.FormatInvariantCulture(length, PostLikeConfigurations.IdMaxLength);

        return result;
    }
}
