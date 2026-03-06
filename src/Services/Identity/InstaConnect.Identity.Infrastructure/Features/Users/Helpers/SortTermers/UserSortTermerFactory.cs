namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.SortTermers;

internal class UserSortTermerFactory : IUsersSortTermerFactory
{
    private readonly IEnumerable<IUsersSortTermer> _sortTermer;

    public UserSortTermerFactory(IEnumerable<IUsersSortTermer> sortTermer)
    {
        _sortTermer = sortTermer;
    }

    public IUsersSortTermer Create(UsersSortTerm sortTerm)
    {
        var sortTermer = _sortTermer.FirstOrDefault(s => s.SortTerm == sortTerm);

        if (sortTermer == null)
        {
            throw new UsersSortTermNotSupportedException(sortTerm);
        }

        return sortTermer;
    }
}
