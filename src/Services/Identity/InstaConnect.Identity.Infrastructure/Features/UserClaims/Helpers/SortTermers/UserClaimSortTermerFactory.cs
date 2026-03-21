namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.SortTermers;

internal class UserClaimSortTermerFactory : IUserClaimsSortTermerFactory
{
    private readonly IEnumerable<IUserClaimsSortTermer> _sortTermer;

    public UserClaimSortTermerFactory(IEnumerable<IUserClaimsSortTermer> sortTermer)
    {
        _sortTermer = sortTermer;
    }

    public IUserClaimsSortTermer Create(UserClaimsSortTerm sortTerm)
    {
        var sortTermer = _sortTermer.FirstOrDefault(s => s.SortTerm == sortTerm);

        if (sortTermer == null)
        {
            throw new UserClaimsSortTermNotSupportedException(sortTerm);
        }

        return sortTermer;
    }
}
