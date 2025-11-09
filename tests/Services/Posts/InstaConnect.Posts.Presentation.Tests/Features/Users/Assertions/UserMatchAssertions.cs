using InstaConnect.Posts.Presentation.Tests.Features.Users.Assertions;

namespace InstaConnect.Posts.Presentation.Tests.Features.Users.Assertions;

public static class UserMatchAssertions
{
    public static void ShouldSatisfy(this User user, UserAddedEventRequest request)
    {
        user.ShouldSatisfy(u => u.Id == request.Id &&
                                u.Name == request.Name &&
                                u.FirstName == request.FirstName &&
                                u.LastName == request.LastName &&
                                u.Email == request.Email &&
                                u.ProfileImage == request.ProfileImage);
    }

    public static void ShouldSatisfy(this User user, UserUpdatedEventRequest request)
    {
        user.ShouldSatisfy(u => u.Id == request.Id &&
                                u.Name == request.Name &&
                                u.FirstName == request.FirstName &&
                                u.LastName == request.LastName &&
                                u.Email == request.Email &&
                                u.ProfileImage == request.ProfileImage);
    }
}
