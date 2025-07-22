namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Factories;
public static class UserTestFactory
{
    public static User Create()
    {
        var user = new User(
            UserDataFaker.GetId(),
            UserDataFaker.GetFirstName(),
            UserDataFaker.GetLastName(),
            UserDataFaker.GetEmail(),
            UserDataFaker.GetName(),
            UserDataFaker.GetProfileImage(),
            UserDataFaker.GetCreatedAt(),
            UserDataFaker.GetUpdatedAt());

        return user;
    }
}
