namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;
internal interface IFollowCollectionFactory
{
    FollowCollection Create(ICollection<Follow> follows, int totalCount, FollowPaginationQuery pagination);
}
