namespace InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
public static class UserMatcher
{
    public static AddUserCommand IsAddUserCommand(AddUserCommandRequest request)
    {
        return Matcher.Is<AddUserCommand>(u => u.Id == request.Id &&
                                               u.Email == request.Email &&
                                               u.Name == request.Name &&
                                               u.FirstName == request.FirstName &&
                                               u.LastName == request.LastName &&
                                               u.ProfileImage == request.ProfileImage);
    }

    public static UpdateUserCommand IsUpdateUserCommand(UpdateUserCommandRequest request)
    {
        return Matcher.Is<UpdateUserCommand>(u => u.Id == request.Id &&
                                                  u.Email == request.Email &&
                                                  u.Name == request.Name &&
                                                  u.FirstName == request.FirstName &&
                                                  u.LastName == request.LastName &&
                                                  u.ProfileImage == request.ProfileImage);
    }

    public static DeleteUserCommand IsDeleteUserCommand(DeleteUserCommandRequest request)
    {
        return Matcher.Is<DeleteUserCommand>(u => u.Id == request.Id);
    }
}
