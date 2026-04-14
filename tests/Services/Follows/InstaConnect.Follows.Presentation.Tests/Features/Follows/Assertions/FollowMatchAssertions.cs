using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;

namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Assertions;

public static class FollowMatchAssertions
{
    extension(AddFollowApiResponse response)
    {
        public void ShouldSatisfy(
        Follow follow,
        AddFollowApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(follow, request));
        }
    }

    extension(GetFollowByIdApiResponse response)
    {
        public void ShouldSatisfy(
        Follow follow,
        GetFollowByIdApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(follow, request));
        }
    }

    extension(GetAllFollowsApiResponse response)
    {
        public void ShouldSatisfy(
        User follower,
        ICollection<Follow> follows,
        GetAllFollowsApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(follower, follows, request));
        }

        public void ShouldSatisfy(
            User follower,
            ICollection<Follow> follows,
            GetAllFollowsApiRequest request,
            ISortEnumTermTransformer<Follow> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(follower, follows, request, termTransformer));
        }
    }

    extension(GetAllFollowsForFollowingApiResponse response)
    {
        public void ShouldSatisfy(
        User following,
        ICollection<Follow> follows,
        GetAllFollowsForFollowingApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(following, follows, request));
        }

        public void ShouldSatisfy(
            User following,
            ICollection<Follow> follows,
            GetAllFollowsForFollowingApiRequest request,
            ISortEnumTermTransformer<Follow> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(following, follows, request, termTransformer));
        }
    }

    extension(ActionResult<AddFollowApiResponse> response)
    {
        public void ShouldSatisfy(
        Follow follow,
        AddFollowApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(follow, request));
        }
    }

    extension(ActionResult<GetFollowByIdApiResponse> response)
    {
        public void ShouldSatisfy(
        Follow follow,
        GetFollowByIdApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(follow, request));
        }
    }

    extension(ActionResult<GetAllFollowsApiResponse> response)
    {
        public void ShouldSatisfy(
        User follower,
        ICollection<Follow> follows,
        GetAllFollowsApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(follower, follows, request));
        }
    }

    extension(ActionResult<GetAllFollowsForFollowingApiResponse> response)
    {
        public void ShouldSatisfy(
        User following,
        ICollection<Follow> follows,
        GetAllFollowsForFollowingApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(following, follows, request));
        }
    }

    extension(Follow follow)
    {
        public void ShouldSatisfy(AddFollowApiRequest request)
        {
            follow.ShouldSatisfy(p => p.Matches(request));
        }
    }
}
