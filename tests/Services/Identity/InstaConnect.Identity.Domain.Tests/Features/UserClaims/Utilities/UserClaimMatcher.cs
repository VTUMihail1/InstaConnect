using InstaConnect.Identity.Events.Features.UserClaims;

namespace InstaConnect.Identity.Domain.Tests.Features.UserClaims.Utilities;

public static class UserClaimMatcher
{
	public static UserClaimInclude IsUserClaimInclude(DeleteUserClaimCommand command, UserClaimInclude include)
	{
		return Matcher.Is<UserClaimInclude>(p => p.Matches(include));
	}

	public static UserClaim IsUserClaim(AddUserClaimCommand command)
	{
		return Matcher.Is<UserClaim>(p => p.Matches(command));
	}

	public static UserClaim IsUserClaim(DeleteUserClaimCommand command)
	{
		return Matcher.Is<UserClaim>(p => p.Matches(command));
	}

	public static UserClaimAddedEventRequest IsUserClaimAddedEventRequest(UserClaim userClaim)
	{
		return Matcher.Is<UserClaimAddedEventRequest>(p => p.Matches(userClaim));
	}

	public static UserClaimDeletedEventRequest IsUserClaimDeletedEventRequest(UserClaim userClaim)
	{
		return Matcher.Is<UserClaimDeletedEventRequest>(p => p.Matches(userClaim));
	}
}
