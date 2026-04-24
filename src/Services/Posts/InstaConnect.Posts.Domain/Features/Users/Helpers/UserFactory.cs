using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Posts.Domain.Features.Users.Helpers;

internal class UserFactory : IUserFactory
{
    public User Create(
        UserId id,
        string firstName,
        string lastName,
        Name name,
        Email email,
        Image? profileImage,
        DateTimeOffset createdAtUtc,
        DateTimeOffset updatedAtUtc)
    {
        var user = new User(
            id,
            firstName,
            lastName,
            email,
            name,
            profileImage,
            createdAtUtc,
            updatedAtUtc);

        return user;
    }
}
