namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.SortProperties;
internal class UserSortPropertyFactory : IUserSortPropertyFactory
{
    private readonly IEnumerable<IUserSortProperty> _userSortProperties;

    public UserSortPropertyFactory(IEnumerable<IUserSortProperty> userSortProperties)
    {
        _userSortProperties = userSortProperties;
    }

    public IUserSortProperty Create(UserSortProperty sortProperty)
    {
        var property = _userSortProperties.FirstOrDefault(s => s.SortProperty == sortProperty);

        if (property == null)
        {
            throw new UserSortPropertyNotSupportedException(sortProperty);
        }

        return property;
    }
}
