namespace InstaConnect.Follows.Application.Tests.Features.Follows.Utilities;

public static class FollowApplicationMatcher
{
	extension(GetAllFollowsQueryRequest request)
	{
		public GetAllFollowsQuery IsGetAllFollowsQuery()
		{
			return Matcher.Is<GetAllFollowsQuery>(p => p.Matches(request));
		}
	}

	extension(GetAllFollowsForFollowingQueryRequest request)
	{
		public GetAllFollowsForFollowingQuery IsGetAllFollowsForFollowingQuery()
		{
			return Matcher.Is<GetAllFollowsForFollowingQuery>(p => p.Matches(request));
		}
	}

	extension(GetFollowByIdQueryRequest request)
	{
		public GetFollowByIdQuery IsGetFollowByIdQuery()
		{
			return Matcher.Is<GetFollowByIdQuery>(p => p.Matches(request));
		}
	}

	extension(AddFollowCommandRequest request)
	{
		public AddFollowCommand IsAddFollowCommand()
		{
			return Matcher.Is<AddFollowCommand>(p => p.Matches(request));
		}
	}

	extension(DeleteFollowCommandRequest request)
	{
		public DeleteFollowCommand IsDeleteFollowCommand()
		{
			return Matcher.Is<DeleteFollowCommand>(p => p.Matches(request));
		}
	}
}
