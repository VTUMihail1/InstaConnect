using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

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

    public static string GetEmailAlreadyConfirmedMessage(UserId id)
    {
        const string Format = "User(id: {0}) already confirmed";

        return Format.FormatCurrentCulture(id.Id);
    }

    public static string GetNameEmailAlreadyConfirmedMessage(Name name)
    {
        const string Format = "User(name: {0}) already confirmed";

        return Format.FormatCurrentCulture(name.Value);
    }

    public static string GetEmailNotConfirmedMessage(UserId id)
    {
        const string Format = "User(id: {0}) not confirmed";

        return Format.FormatCurrentCulture(id.Id);
    }

    public static string GetNameEmailNotConfirmedMessage(Name name)
    {
        const string Format = "User(name: {0}) not confirmed";

        return Format.FormatCurrentCulture(name.Value);
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

    public static string GetIncludeDescriptorsNotSupportedMessage(ICollection<IdentityIncludeDescriptor> descriptors)
    {
        const string Format = "UserDescriptors({0}) is not supported";

        return Format.FormatCurrentCulture(descriptors
            .JoinIncludeDescriptorsAsStringWithComa<IdentityDestinationType, IdentityIncludeType, IdentityIncludeDescriptor>());
    }
}
