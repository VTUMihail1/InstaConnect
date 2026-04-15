using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Application.Tests.Features.Follows.Assertions;

public static class FollowMatchAssertions
{
    extension(AddFollowCommandResponse response)
    {
        public void ShouldSatisfy(
        Follow follow,
        AddFollowCommandRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(follow, request));
        }
    }

    extension(GetFollowByIdQueryResponse response)
    {
        public void ShouldSatisfy(
        Follow follow,
        GetFollowByIdQueryRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(follow, request));
        }
    }

    extension(GetAllFollowsQueryResponse response)
    {
        public void ShouldSatisfy(
        User follower,
        ICollection<Follow> follows,
        GetAllFollowsQueryRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(follower, follows, request));
        }

        public void ShouldSatisfy(
            User follower,
            ICollection<Follow> follows,
            GetAllFollowsQueryRequest request,
            ISortEnumTermTransformer<Follow> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(follower, follows, request, termTransformer));
        }
    }

    extension(GetAllFollowsForFollowingQueryResponse response)
    {
        public void ShouldSatisfy(
        User following,
        ICollection<Follow> follows,
        GetAllFollowsForFollowingQueryRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(following, follows, request));
        }

        public void ShouldSatisfy(
            User following,
            ICollection<Follow> follows,
            GetAllFollowsForFollowingQueryRequest request,
            ISortEnumTermTransformer<Follow> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(following, follows, request, termTransformer));
        }
    }

    extension(Follow follow)
    {
        public void ShouldSatisfy(AddFollowCommandRequest request)
        {
            follow.ShouldSatisfy(p => p.Matches(request));
        }
    }
}
