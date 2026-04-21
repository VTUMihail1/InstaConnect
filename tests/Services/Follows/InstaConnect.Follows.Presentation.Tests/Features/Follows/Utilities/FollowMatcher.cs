namespace InstaConnect.Follows.Presentation.Tests.Features.Follows.Utilities;

public static class FollowMatcher
{
    public static GetAllFollowsQueryRequest IsGetAllFollowsQueryRequest(GetAllFollowsApiRequest request)
    {
        return Matcher.Is<GetAllFollowsQueryRequest>(p => p.Matches(request));
    }

    public static GetAllFollowsForFollowingQueryRequest IsGetAllFollowsForFollowingQueryRequest(GetAllFollowsForFollowingApiRequest request)
    {
        return Matcher.Is<GetAllFollowsForFollowingQueryRequest>(p => p.Matches(request));
    }

    public static GetFollowByIdQueryRequest IsGetFollowByIdQueryRequest(GetFollowByIdApiRequest request)
    {
        return Matcher.Is<GetFollowByIdQueryRequest>(p => p.Matches(request));
    }

    public static AddFollowCommandRequest IsAddFollowCommandRequest(AddFollowApiRequest request)
    {
        return Matcher.Is<AddFollowCommandRequest>(p => p.Matches(request));
    }

    public static DeleteFollowCommandRequest IsDeleteFollowCommandRequest(DeleteFollowApiRequest request)
    {
        return Matcher.Is<DeleteFollowCommandRequest>(p => p.Matches(request));
    }
}
