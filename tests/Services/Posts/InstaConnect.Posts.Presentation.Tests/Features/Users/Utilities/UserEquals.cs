using InstaConnect.Posts.Presentation.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;
public static class UserEquals
{
    public static bool Matches(this User user, UserAddedEventRequest request)
    {
        return user.Id.Matches(request.Id) &&
               user.FirstName == request.FirstName &&
               user.LastName == request.LastName &&
               user.Name.Matches(request.Name) &&
               user.Email.Matches(request.Email) &&
               user.ProfileImage.Matches(request.ProfileImageUrl) &&
               user.CreatedAtUtc == request.CreatedAtUtc &&
               user.UpdatedAtUtc == request.UpdatedAtUtc;
    }

    public static bool Matches(this User user, UserUpdatedEventRequest request)
    {
        return user.Id.Matches(request.Id) &&
               user.FirstName == request.FirstName &&
               user.LastName == request.LastName &&
               user.Name.Matches(request.Name) &&
               user.Email.Matches(request.Email) &&
               user.ProfileImage.Matches(request.ProfileImageUrl) &&
               user.UpdatedAtUtc == request.UpdatedAtUtc;
    }

    public static bool Matches(this AddUserCommandRequest command, UserAddedEventRequest request)
    {
        return command.Id == request.Id &&
               command.Email == request.Email &&
               command.Name == request.Name &&
               command.FirstName == request.FirstName &&
               command.LastName == request.LastName &&
               command.ProfileImageUrl == request.ProfileImageUrl;
    }

    public static bool Matches(this UpdateUserCommandRequest command, UserUpdatedEventRequest request)
    {
        return command.Id == request.Id &&
               command.Email == request.Email &&
               command.Name == request.Name &&
               command.FirstName == request.FirstName &&
               command.LastName == request.LastName &&
               (command.ProfileImageUrl == request.ProfileImageUrl);
    }

    public static bool Matches(this DeleteUserCommandRequest command, UserDeletedEventRequest request)
    {
        return command.Id == request.Id;
    }

    public static bool Matches(this UserApiResponse response, User user)
    {
        return user.Id.Matches(response.Id) &&
               user.Name.Matches(response.Name) &&
               user.ProfileImage.Matches(response.ProfileImageUrl);
    }
}
