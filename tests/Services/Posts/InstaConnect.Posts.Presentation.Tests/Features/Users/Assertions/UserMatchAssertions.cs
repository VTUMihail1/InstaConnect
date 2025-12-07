namespace InstaConnect.Posts.Presentation.Tests.Features.Users.Assertions;

public static class UserMatchAssertions
{
    public static void ShouldSatisfy(this User user, UserAddedEventRequest request)
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

    public static void ShouldSatisfy(this User user, UserUpdatedEventRequest request)
    {
        user.ShouldSatisfy(u => u.Id.Id == request.Id &&
                                u.Name.Value == request.Name &&
                                u.FirstName == request.FirstName &&
                                u.LastName == request.LastName &&
                                u.Email.Value == request.Email &&
                                (u.ProfileImage.IsNull() || u.ProfileImage!.Url == request.ProfileImageUrl) &&
                                u.UpdatedAtUtc == request.UpdatedAtUtc);
    }
}
