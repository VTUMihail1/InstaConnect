using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Posts.Domain.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.Users.Utilities;

public static class UserExceptionErrorMessages
{
    public static string GetNotFoundMessage(UserId id)
    {
        const string Format = "User({0}) does not exist";

        return Format.FormatCurrentCulture(id.Id);
    }

    public static string GetAlreadyExistsMessage(UserId id)
    {
        const string Format = "User({0}) already exists";

        return Format.FormatCurrentCulture(id.Id);
    }

    public static string GetNameAlreadyExistsMessage(Name name)
    {
        const string Format = "User(name: {0}) already exists";

        return Format.FormatCurrentCulture(name.Value);
    }

    public static string GetEmailAlreadyExistsMessage(Email email)
    {
        const string Format = "User(email: {0}) already exists";

        return Format.FormatCurrentCulture(email.Value);
    }

    public static string GetIncludeDescriptorsNotSupportedMessage(ICollection<PostsIncludeDescriptor> includeProperties)
    {
        const string Format = "PostIncludeDescriptors({0}) is not supported";

        return Format.FormatCurrentCulture(includeProperties
            .JoinIncludeDescriptorsAsStringWithComa<PostsDestinationType, PostsIncludeType, PostsIncludeDescriptor>());
    }
}
