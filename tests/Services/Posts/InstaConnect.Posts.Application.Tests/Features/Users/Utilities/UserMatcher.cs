namespace InstaConnect.Posts.Application.Tests.Features.Users.Utilities;
public static class UserMatcher
{
    public static AddUserCommand IsAddUserCommand(AddUserCommandRequest request)
    {
        return Matcher.Is<AddUserCommand>(u => u.Id.Id == request.Id &&
                                               u.Email.Value == request.Email &&
                                               u.Name.Value == request.Name &&
                                               u.FirstName == request.FirstName &&
                                               u.LastName == request.LastName &&
                                               (u.ProfileImage.IsNull() || u.ProfileImage!.Url == request.ProfileImageUrl));
    }

    public static UpdateUserCommand IsUpdateUserCommand(UpdateUserCommandRequest request)
    {
        return Matcher.Is<UpdateUserCommand>(u => u.Id.Id == request.Id &&
                                               u.Email.Value == request.Email &&
                                               u.Name.Value == request.Name &&
                                               u.FirstName == request.FirstName &&
                                               u.LastName == request.LastName &&
                                               (u.ProfileImage.IsNull() || u.ProfileImage!.Url == request.ProfileImageUrl));
    }

    public static DeleteUserCommand IsDeleteUserCommand(DeleteUserCommandRequest request)
    {
        return Matcher.Is<DeleteUserCommand>(u => u.Id.Id == request.Id);
    }
}
