namespace InstaConnect.Chats.Domain.Features.Users.Helpers;

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
