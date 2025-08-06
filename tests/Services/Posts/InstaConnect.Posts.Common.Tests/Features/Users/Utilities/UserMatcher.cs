using InstaConnect.Common.Application.Contracts.Users;
using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Users.Application.Features.Users.Commands.Add;
using InstaConnect.Users.Application.Features.Users.Commands.Delete;

namespace InstaConnect.Users.Common.Tests.Features.Users.Utilities;
public static class UserMatcher
{
    public static AddUserCommandRequest IsAddUserCommand(UserAddedEventRequest request)
    {
        return Matcher.Is<AddUserCommandRequest>(u => u.Id == request.Id &&
                                                      u.Email == request.Email &&
                                                      u.Name == request.Name &&
                                                      u.FirstName == request.FirstName &&
                                                      u.LastName == request.LastName &&
                                                      u.ProfileImage == request.ProfileImage);
    }

    public static UpdateUserCommandRequest IsUpdateUserCommand(UserUpdatedEventRequest request)
    {
        return Matcher.Is<UpdateUserCommandRequest>(u => u.Id == request.Id &&
                                                      u.Email == request.Email &&
                                                      u.Name == request.Name &&
                                                      u.FirstName == request.FirstName &&
                                                      u.LastName == request.LastName &&
                                                      u.ProfileImage == request.ProfileImage);
    }

    public static DeleteUserCommandRequest IsDeleteUserCommand(UserDeletedEventRequest request)
    {
        return Matcher.Is<DeleteUserCommandRequest>(u => u.Id == request.Id);
    }

    public static AddUserCommand IsAddUserRequest(AddUserCommandRequest request)
    {
        return Matcher.Is<AddUserCommand>(u => u.Id == request.Id &&
                                                      u.Email == request.Email &&
                                                      u.Name == request.Name &&
                                                      u.FirstName == request.FirstName &&
                                                      u.LastName == request.LastName &&
                                                      u.ProfileImage == request.ProfileImage);
    }

    public static UpdateUserCommand IsUpdateUserRequest(UpdateUserCommandRequest request)
    {
        return Matcher.Is<UpdateUserCommand>(u => u.Id == request.Id &&
                                                  u.Email == request.Email &&
                                                  u.Name == request.Name &&
                                                  u.FirstName == request.FirstName &&
                                                  u.LastName == request.LastName &&
                                                  u.ProfileImage == request.ProfileImage);
    }

    public static DeleteUserCommand IsDeleteUserRequest(DeleteUserCommandRequest request)
    {
        return Matcher.Is<DeleteUserCommand>(u => u.Id == request.Id);
    }
}
