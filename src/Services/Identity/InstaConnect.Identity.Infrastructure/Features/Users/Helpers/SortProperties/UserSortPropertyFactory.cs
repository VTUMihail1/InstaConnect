namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.SortProperties;
internal class UserSortPropertyFactory : IUserSortPropertyFactory
{
    private readonly IEnumerable<IUserSortProperty> _sortProperties;

    public UserSortPropertyFactory(IEnumerable<IUserSortProperty> sortProperties)
    {
        _sortProperties = sortProperties;
    }

    public IUserSortProperty Create(UserSortProperty sortProperty)
    {
        var property = _sortProperties.FirstOrDefault(s => s.SortTerm == sortProperty);

        if (property == null)
        {
            throw new UserSortPropertyNotSupportedException(sortProperty);
        }

        return property;
    }
}
