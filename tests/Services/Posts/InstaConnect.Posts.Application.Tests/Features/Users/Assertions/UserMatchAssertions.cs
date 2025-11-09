using InstaConnect.Posts.Application.Tests.Features.Users.Assertions;

namespace InstaConnect.Posts.Application.Tests.Features.Users.Assertions;

public static class UserMatchAssertions
{
    public static void ShouldSatisfy(this AddUserCommandResponse response, User user)
    {
        response.ShouldSatisfy(u => u.Id == user.Id &&
                                    u.CreatedAt == user.CreatedAt &&
                                    u.UpdatedAt == user.UpdatedAt);
    }

    public static void ShouldSatisfy(this UpdateUserCommandResponse response, User user)
    {
        response.ShouldSatisfy(u => u.Id == user.Id &&
                                    u.CreatedAt == user.CreatedAt &&
                                    u.UpdatedAt == user.UpdatedAt);
    }

    public static void ShouldSatisfy(this User user, AddUserCommandRequest request)
    {
        user.ShouldSatisfy(u => u.Id == request.Id &&
                                u.Name == request.Name &&
                                u.FirstName == request.FirstName &&
                                u.LastName == request.LastName &&
                                u.Email == request.Email &&
                                u.ProfileImage == request.ProfileImage);
    }

    public static void ShouldSatisfy(this User user, UpdateUserCommandRequest request)
    {
        user.ShouldSatisfy(u => u.Id == request.Id &&
                                u.Name == request.Name &&
                                u.FirstName == request.FirstName &&
                                u.LastName == request.LastName &&
                                u.Email == request.Email &&
                                u.ProfileImage == request.ProfileImage);
    }
}
