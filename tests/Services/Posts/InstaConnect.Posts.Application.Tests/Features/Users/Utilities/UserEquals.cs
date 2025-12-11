using InstaConnect.Posts.Application.Features.Users.Models;
using InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Users.Models.ValueObjects;

namespace InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
public static class UserEquals
{
    public static bool Matches(this AddUserCommandResponse response, User user)
    {
        return response.Response.Matches(user.Id);
    }

    public static bool Matches(this UpdateUserCommandResponse response, User user)
    {
        return response.Response.Matches(user.Id);
    }

    public static bool Matches(this User user, AddUserCommandRequest request)
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

    public static bool Matches(this User user, UpdateUserCommandRequest request)
    {
        return user.Id.Matches(request.Id) &&
               user.FirstName == request.FirstName &&
               user.LastName == request.LastName &&
               user.Name.Matches(request.Name) &&
               user.Email.Matches(request.Email) &&
               user.ProfileImage.Matches(request.ProfileImageUrl) &&
               user.UpdatedAtUtc == request.UpdatedAtUtc;
    }

    public static bool Matches(this AddUserCommand command, AddUserCommandRequest request)
    {
        return command.Id.Matches(request.Id) &&
               command.Email.Matches(request.Email) &&
               command.Name.Matches(request.Name) &&
               command.FirstName == request.FirstName &&
               command.LastName == request.LastName &&
               command.ProfileImage.Matches(request.ProfileImageUrl) &&
               command.CreatedAtUtc == request.CreatedAtUtc &&
               command.UpdatedAtUtc == request.UpdatedAtUtc;
    }

    public static bool Matches(this UpdateUserCommand command, UpdateUserCommandRequest request)
    {
        return command.Id.Matches(request.Id) &&
               command.Email.Matches(request.Email) &&
               command.Name.Matches(request.Name) &&
               command.FirstName == request.FirstName &&
               command.LastName == request.LastName &&
               command.ProfileImage.Matches(request.ProfileImageUrl) &&
               command.UpdatedAtUtc == request.UpdatedAtUtc;
    }

    public static bool Matches(this DeleteUserCommand command, DeleteUserCommandRequest request)
    {
        return command.Id.Matches(request.Id);
    }

    public static bool Matches(this UserIdCommandResponse response, UserId id)
    {
        return id.Matches(response.Id);
    }

    public static bool Matches(this UserQueryResponse response, User user)
    {
        return user.Id.Matches(response.Id) &&
               user.Name.Matches(response.Name) &&
               user.ProfileImage.Matches(response.ProfileImageUrl);
    }
}
