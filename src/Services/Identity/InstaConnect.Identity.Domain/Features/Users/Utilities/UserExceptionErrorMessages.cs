using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Identity.Domain.Models.Requests;

namespace InstaConnect.Identity.Domain.Features.Users.Utilities;

public static class UserExceptionErrorMessages
{
    public static string GetNotFoundMessage(UserId id)
    {
        const string Format = "User(id: {0}) does not exist";

        return Format.FormatCurrentCulture(id.Id);
    }

    public static string GetNameNotFoundMessage(Name name)
    {
        const string Format = "User(name: {0}) does not exist";

        return Format.FormatCurrentCulture(name.Value);
    }

    public static string GetEmailNotFoundMessage(Email email)
    {
        const string Format = "User(email: {0}) does not exist";

        return Format.FormatCurrentCulture(email.Value);
    }

    public static string GetNameAlreadyTakenMessage(Name name)
    {
        const string Format = "User(name: {0}) already taken";

        return Format.FormatCurrentCulture(name.Value);
    }

    public static string GetEmailAlreadyTakenMessage(Email email)
    {
        const string Format = "User(email: {0}) already taken";

        return Format.FormatCurrentCulture(email.Value);
    }

    public static string GetEmailAlreadyConfirmedMessage(Email email)
    {
        const string Format = "User(email: {0}) already confirmed";

        return Format.FormatCurrentCulture(email.Value);
    }

    public static string GetEmailNotConfirmedMessage(Email email)
    {
        const string Format = "User(email: {0}) not confirmed";

        return Format.FormatCurrentCulture(email.Value);
    }

    public static string GetInvalidDetailsMessage(Name name)
    {
        const string Format = "User(name: {0}) has invalid details";

        return Format.FormatCurrentCulture(name.Value);
    }

    public static string GetSortTermNotSupportedMessage(UsersSortTerm sortTerm)
    {
        const string Format = "UserSortTerm(type: {0}) is not supported";

        return Format.FormatCurrentCulture(sortTerm);
    }

    public static string GetInclideDescriptorsNotSupportedMessage(ICollection<IdentityIncludeDescriptor> descriptors)
    {
        const string Format = "UserDescriptors({0}) is not supported";

        return Format.FormatCurrentCulture(descriptors
            .JoinIncludeDescriptorsAsStringWithComa<IdentityDestinationType, IdentityIncludeType, IdentityIncludeDescriptor>());
    }
}
