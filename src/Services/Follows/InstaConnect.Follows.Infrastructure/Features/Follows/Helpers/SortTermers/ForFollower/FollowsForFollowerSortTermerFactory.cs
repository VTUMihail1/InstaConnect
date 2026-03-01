namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.SortTermers.ForFollower;
internal class FollowsForFollowerSortTermerFactory : IFollowsForFollowerSortTermerFactory
{
    private readonly IEnumerable<IFollowsForFollowerSortTermer> _sortTermer;

    public FollowsForFollowerSortTermerFactory(IEnumerable<IFollowsForFollowerSortTermer> sortTermer)
    {
        _sortTermer = sortTermer;
    }

    public IFollowsForFollowerSortTermer Create(FollowsForFollowerSortTerm sortTerm)
    {
        var sortTermer = _sortTermer.FirstOrDefault(s => s.SortTerm == sortTerm);

        if (sortTermer == null)
        {
            throw new FollowForFollowerSortTermNotSupportedException(sortTerm);
        }

        return sortTermer;
    }
}
