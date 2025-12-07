namespace InstaConnect.Posts.Application.Tests.Features.Users.Assertions;

public static class UserMatchAssertions
{
    public static void ShouldSatisfy(this AddUserCommandResponse response, User user)
    {
        response.ShouldSatisfy(u => u.Response.Id == user.Id.Id);
    }

    public static void ShouldSatisfy(this UpdateUserCommandResponse response, User user)
    {
        response.ShouldSatisfy(u => u.Response.Id == user.Id.Id);
    }

    public static void ShouldSatisfy(this User user, AddUserCommandRequest request)
    {
        user.ShouldSatisfy(u => u.Id.Id == request.Id &&
                                u.Name.Value == request.Name &&
                                u.FirstName == request.FirstName &&
                                u.LastName == request.LastName &&
                                u.Email.Value == request.Email &&
                                (u.ProfileImage.IsNull() || u.ProfileImage!.Url == request.ProfileImageUrl) &&
                                u.CreatedAtUtc == request.CreatedAtUtc &&
                                u.UpdatedAtUtc == request.UpdatedAtUtc);
    }

    public static void ShouldSatisfy(this User user, UpdateUserCommandRequest request)
    {
        user.ShouldSatisfy(u => u.Id.Id == request.Id &&
                                u.Name.Value == request.Name &&
                                u.FirstName == request.FirstName &&
                                u.LastName == request.LastName &&
                                u.Email.Value == request.Email &&
                                (u.ProfileImage.IsNotNull() || u.ProfileImage!.Url == request.ProfileImageUrl) &&
                                u.UpdatedAtUtc == request.UpdatedAtUtc);
    }
}
