using InstaConnect.Follows.Domain.Features.Follows.Models.Requests;
using InstaConnect.Follows.Infrastructure.Features.Follows.Models;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;
public interface IFollowQueryFactory
{
    GetAllFollowsByFollowerQuerySpecification CreateGetAllByFollower(GetAllFollowsByFollowerQuery query);

    GetAllFollowsByFollowerTotalCountQuerySpecification CreateGetAllByFollowerTotalCount(FollowByFollowerFilterQuery query);

    GetAllFollowsByFollowingQuerySpecification CreateGetAllByFollowing(GetAllFollowsByFollowingQuery query);

    GetAllFollowsByFollowingTotalCountQuerySpecification CreateGetAllByFollowingTotalCount(FollowByFollowingFilterQuery query);

    GetFollowByIdQuerySpecification CreateGetById(
        string followerId,
        string followingId);
}
