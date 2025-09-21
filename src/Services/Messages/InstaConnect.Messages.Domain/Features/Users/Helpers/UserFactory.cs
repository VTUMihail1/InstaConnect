
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.Posts.Helpers;

internal class UserFactory : IUserFactory
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public UserFactory(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public User Create(
        string id,
        string firstName,
        string lastName,
        string name,
        string email,
        string? profileImage)
    {
        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        var user = new User(
            id,
            firstName,
            lastName,
            email,
            name,
            profileImage,
            utcNow,
            utcNow);

        return user;
    }
}
