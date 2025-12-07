namespace InstaConnect.Posts.Presentation.Tests.Features.Users.Utilities;
public static class UserMatcher
{
    public static AddUserCommandRequest IsAddUserCommandRequest(UserAddedEventRequest request)
    {
        return Matcher.Is<AddUserCommandRequest>(u => u.Id == request.Id &&
                                                      u.Email == request.Email &&
                                                      u.Name == request.Name &&
                                                      u.FirstName == request.FirstName &&
                                                      u.LastName == request.LastName &&
                                                      u.ProfileImageUrl == request.ProfileImageUrl &&
                                                      u.CreatedAtUtc == request.CreatedAtUtc &&
                                                      u.UpdatedAtUtc == request.UpdatedAtUtc);
    }

    public static UpdateUserCommandRequest IsUpdateUserCommandRequest(UserUpdatedEventRequest request)
    {
        return Matcher.Is<UpdateUserCommandRequest>(u => u.Id == request.Id &&
                                                         u.Email == request.Email &&
                                                         u.Name == request.Name &&
                                                         u.FirstName == request.FirstName &&
                                                         u.LastName == request.LastName &&
                                                         u.ProfileImageUrl == request.ProfileImageUrl &&
                                                         u.UpdatedAtUtc == request.UpdatedAtUtc);
    }

    public static DeleteUserCommandRequest IsDeleteUserCommandRequest(UserDeletedEventRequest request)
    {
        return Matcher.Is<DeleteUserCommandRequest>(u => u.Id == request.Id);
    }
}
