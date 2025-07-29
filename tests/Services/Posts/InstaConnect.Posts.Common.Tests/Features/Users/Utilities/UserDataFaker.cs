using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Utilities;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

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

    public static string GetFirstName()
    {
        return DataFaker.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength);
    }

    public static string GetLastName()
    {
        return DataFaker.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength);
    }

    public static string GetEmail()
    {
        return DataFaker.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength);
    }

    public static string GetProfileImage()
    {
        return DataFaker.GetAverageString(UserConfigurations.ProfileImageMaxLength, UserConfigurations.ProfileImageMaxLength);
    }

    public static DateTimeOffset GetCreatedAt()
    {
        return DataFaker.GetMaxDate();
    }

    public static DateTimeOffset GetUpdatedAt()
    {
        return DataFaker.GetMaxDate();
    }
}
