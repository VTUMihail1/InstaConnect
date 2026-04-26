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
        Name name,
        string firstName,
        string lastName,
        Email email,
        string passwordHash)
    {
        var id = _guidProvider.NewGuid().ToString();
        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        var user = new User(
            new(id),
            firstName,
            lastName,
            email,
            name,
            passwordHash,
            false,
            null,
            utcNow,
            utcNow);

        return user;
    }
}
