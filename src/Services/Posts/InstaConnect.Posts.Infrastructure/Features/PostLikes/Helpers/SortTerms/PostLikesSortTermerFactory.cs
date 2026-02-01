namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.SortTerms;

internal class PostLikesSortTermerFactory : IPostLikesSortTermerFactory
{
    private readonly IEnumerable<IPostLikesSortTermer> _sortTermer;

    public PostLikesSortTermerFactory(IEnumerable<IPostLikesSortTermer> sortTermer)
    {
        _sortTermer = sortTermer;
    }

    public IPostLikesSortTermer Create(PostLikesSortTerm sortTerm)
    {
        var sortTermer = _sortTermer.FirstOrDefault(s => s.SortTerm == sortTerm);

        if (sortTermer == null)
        {
            throw new PostLikeSortTermerNotSupportedException(sortTerm);
        }

        return sortTermer;
    }
}
