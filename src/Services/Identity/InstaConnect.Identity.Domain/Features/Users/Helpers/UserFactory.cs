namespace InstaConnect.Identity.Domain.Features.Users.Helpers;

internal class UserFactory : IUserFactory
{
    private readonly IGuidProvider _guidProvider;
    private readonly IDateTimeProvider _dateTimeProvider;

    public UserFactory(
        IGuidProvider guidProvider,
        IDateTimeProvider dateTimeProvider)
    {
        _guidProvider = guidProvider;
        _dateTimeProvider = dateTimeProvider;
    }

    public User Create(
        string name,
        string firstName,
        string lastName,
        string email,
        string passwordHash,
        string? profileImage)
    {
        var id = _guidProvider.NewGuid().ToString();
        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        var user = new User(
            id,
            firstName,
            lastName,
            email,
            name,
            passwordHash,
            false,
            profileImage,
            utcNow,
            utcNow);

        return user;
    }
}
