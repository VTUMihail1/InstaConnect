namespace InstaConnect.Follows.Tests.Features.Follows.Utilities;

public static class FollowDataFaker
{
	public static DateTimeOffset GetCreatedAtUtc()
	{
		return DataFaker.GetRecentDate();
	}

	public static int GetPage()
	{
		const int Page = 1;

		return Page;
	}

	public static int GetPageSize()
	{
		const int PageSize = 20;

		return PageSize;
	}

	public static FollowsSortTerm GetSortTerm()
	{
		const FollowsSortTerm SortTerm = FollowsSortTerm.ByCreatedAt;

		return SortTerm;
	}

	public static FollowsForFollowingSortTerm GetForFollowingSortTerm()
	{
		const FollowsForFollowingSortTerm SortTerm = FollowsForFollowingSortTerm.ByCreatedAt;

		return SortTerm;
	}
}
