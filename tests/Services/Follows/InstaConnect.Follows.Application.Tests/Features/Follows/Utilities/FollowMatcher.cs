namespace InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;

public static class FollowMatcher
{
    public static GetAllFollowsQuery IsGetAllFollowsQuery(GetAllFollowsQueryRequest request)
    {
        return Matcher.Is<GetAllFollowsQuery>(p => p.Matches(request));
    }

    public static GetAllFollowsForFollowingQuery IsGetAllFollowsForFollowingQuery(GetAllFollowsForFollowingQueryRequest request)
    {
        return Matcher.Is<GetAllFollowsForFollowingQuery>(p => p.Matches(request));
    }

    public static GetFollowByIdQuery IsGetFollowByIdQuery(GetFollowByIdQueryRequest request)
    {
        return Matcher.Is<GetFollowByIdQuery>(p => p.Matches(request));
    }

    public static AddFollowCommand IsAddFollowCommand(AddFollowCommandRequest request)
    {
        return Matcher.Is<AddFollowCommand>(p => p.Matches(request));
    }

    public static DeleteFollowCommand IsDeleteFollowCommand(DeleteFollowCommandRequest request)
    {
        return Matcher.Is<DeleteFollowCommand>(p => p.Matches(request));
    }
}
